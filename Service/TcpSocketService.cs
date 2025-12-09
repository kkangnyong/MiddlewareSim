using Mythosia.Integrity.CRC;
using Mythosia.Security.Cryptography;
using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.ViewModel;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SimReeferMiddlewareSystemWPF.Service
{
    public class TcpSocketService : ITcpSocketService
    {
        private Socket _connectSocket { get; set; }
        private SocketAsyncEventArgs sendArgs { get; set; }
        private readonly string ACK_00 = "2B-56-EF-BF-BD-36-EF-BF-BD-72-6E-5D-EF-BF-BD-EF-BF-BD-74-EF-BF-BD-D6-A2";
        protected byte[] SeedKey { get; } = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5];
        public Action? SocketAsyncConnected { get; set; }
        public Action? SocketAsyncDisconnected { get; set; }
        public Action<string>? SocketAsyncError { get; set; }
        public Action<byte[]>? NoSynchronizationSetupInfo { get; set; }
        public Action<IDictionary<string, string>, byte[]>? SynchronizationSetupInfo { get; set; }
        public Action<byte[]>? RecievedByteToString { get; set; }

        private MainViewModel _mainView;
        public MainViewModel MainView { get { if (_mainView == null) _mainView = new MainViewModel(); return _mainView.Instance; } }

        private string _ccpr = "CCPR";
        private string _Interval = "Interval";
        private string _gpsTimeout = "GPS Timeout";
        private string _gpsStableTime = "GPS Stable Time";
        private string _wireConnectionTimeout = "Wire Connection Timeout";
        private string _commRetryCount = "Comm Retry Count";
        private string _rcCount = "RcCount";
        private string _totalStandbyCount = "Total Standby Count";
        private string _accelShockUpper = "Accel Shock Upper";
        private string _setTempLower = "Set Temp Lower";
        private string _setTempUpper = "Set Temp Upper";
        private string _humidLower = "Humid Lower";
        private string _humidUpper = "Humid Upper";
        private string _stateChangedAlarm = "State Changed Alarm";
        private string _cutOffVoltage = "Cut Off Voltage";

        public void Connection(string _ip, ushort _port)
        {
            try
            {
                string ip = !string.IsNullOrEmpty(_ip) ? _ip : "192.168.10.14";
                _connectSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress serverAddress = null;

                if (!IPAddress.TryParse(ip, out serverAddress))
                {
                    if (Dns.GetHostEntry(ip).AddressList != null && Dns.GetHostEntry(ip).AddressList.Count() > 0)
                    {
                        serverAddress = Dns.GetHostEntry(ip).AddressList[0];
                    }
                }

                IPEndPoint clientEndPoint = new IPEndPoint(serverAddress, (int)_port);

                SocketAsyncEventArgs args = new SocketAsyncEventArgs();
                args.Completed += Args_Completed;
                args.RemoteEndPoint = clientEndPoint;

                _connectSocket.ConnectAsync(args);
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Socket Exception: {ex.ToString()}");
                SocketAsyncError?.Invoke($"Socket Exception: {ex.ToString()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Another Exception: {ex.ToString()}");
                SocketAsyncError?.Invoke($"Another Exception: {ex.ToString()}");
            }
        }

        private void Args_Completed(object? sender, SocketAsyncEventArgs args)
        {
            if (args.SocketError != SocketError.Success)
            {
                SocketAsyncError?.Invoke(args.SocketError.ToString());
                return;
            }

            sendArgs = new SocketAsyncEventArgs();
            sendArgs.Completed += Args_SendCompleted;
            SocketAsyncConnected?.Invoke();

            SocketAsyncEventArgs receiveArgs = new SocketAsyncEventArgs();
            receiveArgs.SetBuffer(new byte[1000], 0, 1000);
            receiveArgs.Completed += ReceiveArgs_Completed;

            bool pending = _connectSocket.ReceiveAsync(receiveArgs);
            if (!pending)
            {
                ReceiveArgs_Completed(null, receiveArgs);
            }
        }

        private bool IsFotaTest = false;
        private void ReceiveArgs_Completed(object? sender, SocketAsyncEventArgs args)
        {
            try
            {
                if (args.BytesTransferred > 0 && args.SocketError == SocketError.Success)
                {
                    string recvData = Encoding.UTF8.GetString(args.Buffer, args.Offset, args.BytesTransferred);
                    byte[] bytes = Encoding.UTF8.GetBytes(recvData);
                    string recvDataBytesToString = BitConverter.ToString(bytes);
                    byte[] recvOriginData = null;
                    //최초 프로토콜 버전을 전송할 때 Ack: 01을 받은 후 진입 해당응답은 SeedKey 적용이 안되어있음(Protocol을 정해야하는 최초 시퀀스이기에 SeedKey적용이 없는것으로 판단)
                    if (recvDataBytesToString.Equals("01"))
                    {
                        recvOriginData = DecryptReceivedMsg(args.Buffer);

                        if (recvOriginData.Length <= 2 && recvOriginData.Sum(x => x) == 0)
                        {
                            NoSynchronizationSetupInfo?.Invoke(recvOriginData);
                        }
                        else
                        {
                            string[] msgString = new string[] {
                                _ccpr, //1
                                _Interval, //0,30
                                _gpsTimeout, //120
                                _gpsStableTime, //30
                                _wireConnectionTimeout, //60
                                _commRetryCount, //3
                                _rcCount, //6
                                _totalStandbyCount, //0,0
                                _accelShockUpper, //9
                                _setTempLower, //0,0
                                _setTempUpper, //0,0
                                _humidLower, //0,0
                                _humidUpper, //0,0
                                _stateChangedAlarm, //0,0
                                _cutOffVoltage }; //3,40 

                            IDictionary<string, string> syncDataDics = new Dictionary<string, string>();

                            for (int i = 0; i < msgString.Length; i++)
                            {
                                if (msgString[i].ToUpper().Equals(_ccpr.ToUpper())) { syncDataDics.Add(msgString[i], recvOriginData[1].ToString()); }
                                else if (msgString[i].ToUpper().Equals(_Interval.ToUpper())) { syncDataDics.Add(msgString[i], recvOriginData[3].ToString()); }
                                else if (msgString[i].ToUpper().Equals(_gpsTimeout.ToUpper())) { syncDataDics.Add(msgString[i], recvOriginData[4].ToString()); }
                                else if (msgString[i].ToUpper().Equals(_gpsStableTime.ToUpper())) { syncDataDics.Add(msgString[i], recvOriginData[5].ToString()); }
                                else if (msgString[i].ToUpper().Equals(_wireConnectionTimeout.ToUpper())) { syncDataDics.Add(msgString[i], recvOriginData[6].ToString()); }
                                else if (msgString[i].ToUpper().Equals(_commRetryCount.ToUpper())) { syncDataDics.Add(msgString[i], recvOriginData[7].ToString()); }
                                else if (msgString[i].ToUpper().Equals(_rcCount.ToUpper())) { syncDataDics.Add(msgString[i], recvOriginData[8].ToString()); }
                                else if (msgString[i].ToUpper().Equals(_totalStandbyCount.ToUpper())) { syncDataDics.Add(msgString[i], recvOriginData[10].ToString()); }
                                else if (msgString[i].ToUpper().Equals(_accelShockUpper.ToUpper())) { syncDataDics.Add(msgString[i], recvOriginData[11].ToString()); }
                                else if (msgString[i].ToUpper().Equals(_setTempLower.ToUpper())) { syncDataDics.Add(msgString[i], recvOriginData[13].ToString()); }
                                else if (msgString[i].ToUpper().Equals(_setTempUpper.ToUpper())) { syncDataDics.Add(msgString[i], recvOriginData[15].ToString()); }
                                else if (msgString[i].ToUpper().Equals(_humidLower.ToUpper())) { syncDataDics.Add(msgString[i], recvOriginData[17].ToString()); }
                                else if (msgString[i].ToUpper().Equals(_humidUpper.ToUpper())) { syncDataDics.Add(msgString[i], recvOriginData[19].ToString()); }
                                else if (msgString[i].ToUpper().Equals(_stateChangedAlarm.ToUpper())) { syncDataDics.Add(msgString[i], recvOriginData[21].ToString()); }
                                else if (msgString[i].ToUpper().Equals(_cutOffVoltage.ToUpper())) { syncDataDics.Add(msgString[i], recvOriginData[22] + "." + recvOriginData[23]); }
                            }

                            SynchronizationSetupInfo?.Invoke(syncDataDics, recvOriginData);
                        }

                    }

                    //반자동 시뮬레이터 진행이 아닌 수동으로 바이트 적어서 보내는 경우 진입, 수동 시뮬레이터
                    //수동으로 고정된 메시지를 전송하기에 응답메시지를 보여주기만 하면 되고 응답메시지에 따라 액션은 필요없음
                    //if (_manualSendForm != null)
                    //{
                    //    BeginInvokeWork(_manualSendForm.GetRecievedmsgBox, () => { _manualSendForm.GetRecievedmsgBox.Text = recvDataBytesToString; });



                    //    if (recvData.StartsWith("fw_version"))
                    //    {
                    //        IsFotaTest = true;
                    //        string start = "start";
                    //        byte[] msgBytes = Encoding.UTF8.GetBytes(start);
                    //        SendMsg(msgBytes, false, false);
                    //    }

                    //    if (IsFotaTest)
                    //    {
                    //        string start = "next";
                    //        byte[] msgBytes = Encoding.UTF8.GetBytes(start);
                    //        SendMsg(msgBytes, false, false);
                    //    }
                    //}
                    ////수동이 아닌 Panel에 있는 항목 값들을 수정하고 버튼 클릭으로 테스트를 진행 할 수 있는 반자동 시뮬레이터
                    //else
                    //{
                    //    BeginInvokeWork(txt_recievedmsg, () => { txt_recievedmsg.Text = recvDataBytesToString; });
                    //    //최초 프로토콜 버전을 전송할 때 Ack: 01을 받은 후 진입 해당응답은 SeedKey 적용이 안되어있음(Protocol을 정해야하는 최초 시퀀스이기에 SeedKey적용이 없는것으로 판단)
                    //    if (recvDataBytesToString.Equals("01"))
                    //    {
                    //        BeginInvokeWork(cbBoxMWProtocolVerList, () =>
                    //        {
                    //            cbBoxMWProtocolVerList.Enabled = false;
                    //            btn_send_protocolVer.Enabled = false;
                    //        });
                    //        BeginInvokeWork(pnlProtocolVer, () =>
                    //        {
                    //            uCtrlVer.SetEnable(true);
                    //            uCtrlVer.SetEnableDeviceInfoControl(true);
                    //        });
                    //    }
                    //    //동기화가 필요할 경우 진입
                    //    else if (!recvDataBytesToString.Equals(ACK_00) && recvDataBytesToString.Length > 2)
                    //    {
                    //        BeginInvokeWork(pnlProtocolVer, () =>
                    //        {
                    //            uCtrlVer.SetEnableDeviceInfoControl(false);
                    //            uCtrlVer.SetEnableSetupInfoControl(true);
                    //        });
                    //    }
                    //    //동기화가 필요없거나 Ack로 00을 받았을 때 진입
                    //    else if (recvDataBytesToString.Equals(ACK_00))
                    //    {
                    //        BeginInvokeWork(pnlProtocolVer, () =>
                    //        {
                    //            uCtrlVer.SetEnableDeviceInfoControl(false);
                    //            uCtrlVer.SetEnableSetupInfoControl(false);
                    //            uCtrlVer.SetEnableStartDataControl(true);
                    //        });
                    //    }
                    //}


                    if (recvData.StartsWith("fw_version"))
                    {
                        IsFotaTest = true;
                        string start = "start";
                        byte[] msgBytes = Encoding.UTF8.GetBytes(start);
                        SendMsg(msgBytes, false, false);
                    }

                    if (IsFotaTest)
                    {
                        string start = "next";
                        byte[] msgBytes = Encoding.UTF8.GetBytes(start);
                        SendMsg(msgBytes, false, false);
                    }

                    recvOriginData = DecryptReceivedMsg(args.Buffer);
                    RecievedByteToString?.Invoke(recvOriginData);
                    ReceiveArgs_Completed(null, args);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (Exception ex)
            {
                SocketAsyncError?.Invoke(ex.Message);
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                SocketAsyncDisconnected?.Invoke();
                Disconnection();
            }
        }

        private void Args_SendCompleted(object? sender, SocketAsyncEventArgs args)
        {
            if (args.BytesTransferred > 0 && args.SocketError == SocketError.Success)
            {
                sendArgs.BufferList = null;
            }
        }

        private byte[] DecryptReceivedMsg(byte[] receivedBytes)
        {
            byte[] recvBytes = receivedBytes;
            int recv = _connectSocket.Receive(recvBytes);
            byte[] recvRaw = new byte[recv];
            for (int i = 0; i < recv; i++)
            {
                recvRaw[i] = recvBytes[i];
            }
            return recvRaw.DecryptSEED(SeedKey).ToArray();
        }

        public bool BuildSendMessage(int totalDataBytesLength, List<byte[]> dataBytesList)
        {
            byte[] msgBytes = new byte[totalDataBytesLength];

            int index = 0;
            foreach (byte[] dataBytes in dataBytesList)
            {
                Array.Copy(dataBytes, 0, msgBytes, index, dataBytes.Length);
                index += dataBytes.Length;
            }
            return SendMsg(msgBytes, false, true);
        }

        public bool SendMsg(byte[] messages, bool isVer, bool isAddCrc)
        {
            try
            {
                if (messages.Length > 0)
                {
                    IEnumerable<byte> datas = messages;

                    if (!isVer && isAddCrc)
                    {
                        byte[] tempArray = datas.ToArray();

                        uint crc = tempArray.CRC32();
                        byte[] crcBytes = BitConverter.GetBytes(crc);

                        Array.Reverse(crcBytes);

                        byte[] sumArray = new byte[tempArray.Length + crcBytes.Length];

                        Array.Copy(tempArray, 0, sumArray, 0, tempArray.Length);
                        Array.Copy(crcBytes, 0, sumArray, tempArray.Length, crcBytes.Length);

                        datas = sumArray.EncryptSEED(SeedKey);

                        messages = datas.ToArray();
                    }

                    sendArgs.SetBuffer(messages, 0, messages.Length);
                    _connectSocket.SendAsync(sendArgs);
                    return true;
                }
            }
            catch (SocketException se)
            {
                Console.WriteLine($"SocketException -> {se.ToString()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine();
            }
            return false;
        }

        public void Disconnection()
        {
            _connectSocket?.Close();
            _connectSocket?.Dispose();

            IsFotaTest = false;
        }

        public void RepeatDataSendOption(IProtocolVer ownVer, IModelDataService modelData, bool isRepeat, int repeatCnt, short code)
        {
            byte[] msgBytes = null;
            if (ownVer.ProtocolVersion == (short)ProtocolVerType.V8)
            {
                msgBytes = modelData._resultDataValuesToBytes;
            }
            else
            {
                msgBytes = Encoding.UTF8.GetBytes(modelData._dataValuesToJsonString);
            }

            if (!isRepeat || repeatCnt <= 0)
            {
                SendMsg(msgBytes, false, true);
            }
            else
            {
                if (code == (short)ProtocolCode.Last)
                {
                    SendMsg(msgBytes, false, true);
                    repeatCnt -= 1;
                }

                msgBytes = CodeValuesModifyMethod(msgBytes, code, ownVer.ProtocolVersion);
                int index = 0;
                for (int i = 1; i <= repeatCnt; i++)
                {
                    index = i;
                    if (i == repeatCnt && code == (short)ProtocolCode.Continue)
                    {
                        msgBytes = CodeValuesModifyMethod(msgBytes, (short)ProtocolCode.Last, ownVer.ProtocolVersion);
                    }

                    if (code == (short)ProtocolCode.Last) index += 1;

                    DateTime now = DateTime.Now;
                    if (ownVer.ProtocolVersion == (short)ProtocolVerType.V8)
                    {
                        msgBytes[2] = Convert.ToByte(index);
                        msgBytes[7] = Convert.ToByte(now.ToString("yy"));
                        msgBytes[8] = Convert.ToByte(now.Month);
                        msgBytes[9] = Convert.ToByte(now.Day);
                        msgBytes[10] = Convert.ToByte(now.Hour);
                        msgBytes[11] = Convert.ToByte(now.Minute);
                        msgBytes[12] = Convert.ToByte(now.Second);
                    }
                    else
                    {
                        string jsonDatas = Encoding.UTF8.GetString(msgBytes);
                        CTRGenericPacket jsonValue = JsonSerializer.Deserialize<CTRGenericPacket>(msgBytes);

                        string fromDeviceBody = jsonValue.DeviceBase64;

                        byte[] jsonToByte = Convert.FromBase64String(fromDeviceBody);

                        jsonToByte[1] = Convert.ToByte(index);
                        jsonToByte[6] = Convert.ToByte(now.ToString("yy"));
                        jsonToByte[7] = Convert.ToByte(now.Month);
                        jsonToByte[8] = Convert.ToByte(now.Day);
                        jsonToByte[9] = Convert.ToByte(now.Hour);
                        jsonToByte[10] = Convert.ToByte(now.Minute);
                        jsonToByte[11] = Convert.ToByte(now.Second);

                        string toDeviceBody = Convert.ToBase64String(jsonToByte);

                        jsonDatas = jsonDatas.Replace(fromDeviceBody, toDeviceBody);
                        msgBytes = Encoding.UTF8.GetBytes(jsonDatas);
                    }
                    Thread.Sleep(500);

                    MainView.Count = index;

                    if (code == (short)ProtocolCode.Last)
                    {
                        modelData.InitGenericData();
                        string sequence = "start data";
                        modelData.SetDataValues(new List<byte[]> { modelData.GetStringsToByteArray(sequence, (ushort)sequence.Length, false, true) });
                        BuildSendMessage(modelData._totalDataBytesLength, modelData._dataValuesList);
                        Thread.Sleep(200);
                    }

                    SendMsg(msgBytes, false, true);
                    Thread.Sleep(200);
                }
                Disconnection();
            }
        }

        private byte[] CodeValuesModifyMethod(byte[] msgBytes, short code, short ver)
        {
            if (ver == (short)ProtocolVerType.V8)
            {
                msgBytes[0] = Convert.ToByte(code);
            }
            else
            {
                string tempJson = Encoding.UTF8.GetString(msgBytes);
                string jsonDatas = tempJson;
                jsonDatas = jsonDatas.Substring(jsonDatas.IndexOf("{") + 1, jsonDatas.IndexOf(",") - 1).Trim();

                tempJson = tempJson.Replace(jsonDatas, $"\"cod\": {code}");
                msgBytes = Encoding.UTF8.GetBytes(tempJson);
            }
            return msgBytes;
        }
    }

    public class CTRGenericPacket
    {
        [JsonPropertyName("cod")]
        public byte HeaderValue { get; set; }

        [JsonPropertyName("dev")]
        public string DeviceBase64 { get; set; } = string.Empty;

        [JsonPropertyName("ref")]
        public string ReeferBase64 { get; set; } = string.Empty;

        [JsonPropertyName("sen")]
        public SensorPacket[] Sensors { get; set; }
    }

    public class SensorPacket
    {
        [JsonPropertyName("i")]
        public byte Index { get; set; }

        [JsonPropertyName("t")]
        public byte SensorType { get; set; }

        [JsonPropertyName("d")]
        public string DataBase64 { get; set; } = string.Empty;
    }

    public enum ProtocolVerType
    { 
        None = 0,
        [Description("Protocol Ver8")]
        V8 = 8,
        [Description("Protocol Ver9")]
        V9 = 9,
        [Description("Protocol Ver10")]
        V10 = 10
    }

    public enum ProtocolCode
    { 
        Unknown = 0,
        [Description("Continue Code")]
        Continue = 1,
        [Description("Last Code")]
        Last = 17
    }
}
