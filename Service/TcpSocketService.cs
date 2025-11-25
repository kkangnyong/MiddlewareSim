using Mythosia.Integrity.CRC;
using Mythosia.Security.Cryptography;
using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.View.ProtocolVer.Ver8;
using SimReeferMiddlewareSystemWPF.View.ProtocolVer.Ver9;
using System.Net;
using System.Net.Sockets;
using System.Text;

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
        public Action? NoSynchronizationSetupInfo { get; set; }
        public Action? SynchronizationSetupInfo { get; set; }

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
                //BeginInvokeWork(txt_recievedmsg, () =>
                //{
                //    txt_recievedmsg.Text = string.Empty;
                //});
            }
            catch (SocketException ex)
            {
                //MessageBox.Show($"Socket 연결 정보가 잘 못 되었습니다.\r\n{ex.ToString()}", "Server disconnected", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Console.WriteLine(args.SocketError.ToString());
                //BeginInvokeWork(btn_connect, () =>
                //{
                //    btn_connect.Enabled = true;
                //});
                SocketAsyncError?.Invoke(args.SocketError.ToString());
                return;
            }

            sendArgs = new SocketAsyncEventArgs();
            sendArgs.Completed += Args_SendCompleted;
            SocketAsyncConnected?.Invoke();

            SocketAsyncEventArgs receiveArgs = new SocketAsyncEventArgs();
            receiveArgs.SetBuffer(new byte[1024], 0, 1024);
            receiveArgs.Completed += ReceiveArgs_Completed;

            bool pending = _connectSocket.ReceiveAsync(receiveArgs);
            if (!pending)
            {
                ReceiveArgs_Completed(null, receiveArgs);
            }
            //BeginInvokeWork(btn_connect, () => { btn_connect.Enabled = false; });
            //BeginInvokeWork(btn_send_protocolVer, () =>
            //{
            //    if (cbBoxMWProtocolVerList.SelectedItem.ToString().ToUpper().StartsWith("0"))
            //    {
            //        btn_send_protocolVer.Enabled = true;
            //    }
            //});
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

                    //BeginInvokeWork(txt_recievedmsg, () => { txt_recievedmsg.Text = recvDataBytesToString; });
                    //최초 프로토콜 버전을 전송할 때 Ack: 01을 받은 후 진입 해당응답은 SeedKey 적용이 안되어있음(Protocol을 정해야하는 최초 시퀀스이기에 SeedKey적용이 없는것으로 판단)
                    if (recvDataBytesToString.Equals("01"))
                    {
                        //BeginInvokeWork(cbBoxMWProtocolVerList, () =>
                        //{
                        //    cbBoxMWProtocolVerList.Enabled = false;
                        //    btn_send_protocolVer.Enabled = false;
                        //});
                        //BeginInvokeWork(pnlProtocolVer, () =>
                        //{
                        //    uCtrlVer.SetEnable(true);
                        //    uCtrlVer.SetEnableDeviceInfoControl(true);
                        //});
                    }
                    //동기화가 필요할 경우 진입
                    else if (!recvDataBytesToString.Equals(ACK_00) && recvDataBytesToString.Length > 2)
                    {
                        //BeginInvokeWork(pnlProtocolVer, () =>
                        //{
                        //    uCtrlVer.SetEnableDeviceInfoControl(false);
                        //    uCtrlVer.SetEnableSetupInfoControl(true);
                        //});
                        SynchronizationSetupInfo?.Invoke();

                    }
                    //동기화가 필요없거나 Ack로 00을 받았을 때 진입
                    else if (recvDataBytesToString.Equals(ACK_00))
                    {
                        //BeginInvokeWork(pnlProtocolVer, () =>
                        //{
                        //    uCtrlVer.SetEnableDeviceInfoControl(false);
                        //    uCtrlVer.SetEnableSetupInfoControl(false);
                        //    uCtrlVer.SetEnableStartDataControl(true);
                        //});
                        NoSynchronizationSetupInfo?.Invoke();
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


                    bool pending = _connectSocket.ReceiveAsync(args);
                    if (!pending)
                    {
                        ReceiveArgs_Completed(null, args);
                        //MessageBox.Show($"응답 값이 없습니다. 프로토콜 버전 또는 전송 데이터를 확인해주세요.", "Server disconnected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    //if (_manualSendForm != null)
                    //{
                    //    BeginInvokeWork(_manualSendForm.GetRecievedmsgBox, () => { _manualSendForm.GetRecievedmsgBox.Text = "Disconnected to server!!!\r\nPlease reconnect to the server."; });
                    //}
                    //BeginInvokeWork(txt_recievedmsg, () => { txt_recievedmsg.Text = "Disconnected to server!!!\r\nPlease reconnect to the server."; });
                    SocketAsyncDisconnected?.Invoke();
                    Disconnection();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Args_SendCompleted(object? sender, SocketAsyncEventArgs args)
        {
            if (args.BytesTransferred > 0 && args.SocketError == SocketError.Success)
            {
                sendArgs.BufferList = null;
            }
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

            //BeginInvokeWork(this, () =>
            //{
            //    btn_connect.Enabled = true;
            //    btn_send_protocolVer.Enabled = false;
            //    cbBoxMWProtocolVerList.Enabled = true;
            //});

            //if (uCtrlVer == null) { return; }

            //uCtrlVer.SetEnableAllControl(false);
            //uCtrlVer.SetEnable(false);

            //Button startDC = uCtrlVer.StartDataCtrl ?? new Button();
            //Button startCC = uCtrlVer.StartCommandCtrl ?? new Button();

            //startDC.Enabled = false;
            //startCC.Enabled = false;
            IsFotaTest = false;
        }

        public void RepeatDataSendOption(byte[] msgBytes)
        {
            SendMsg(msgBytes, false, true);
            //if (!chkBoxRepeat.Checked || numRepeatCnt.Value <= 0)
            //{
            //    SendMsg(msgBytes, false, true);
            //}
            //else
            //{
            //    if (cbBoxRepeatType.SelectedIndex == 0) return;
            //    lblRepeatCnt.Text = "0";

            //    if (cbBoxRepeatType.SelectedIndex == (int)ProtocolCodeType.LastDataCode) SendMsg(msgBytes, false, true);

            //    uCtrlVer.SetEnable(false);

            //    string codeText = MiddlewareRepeatCodeTypes[cbBoxRepeatType.SelectedIndex];
            //    msgBytes = CodeValuesModifyMethod(msgBytes, codeText, verType);

            //    for (int i = 1; i <= numRepeatCnt.Value; i++)
            //    {
            //        if (i == numRepeatCnt.Value && cbBoxRepeatType.SelectedIndex == (int)ProtocolCodeType.CommonDataCode)
            //        {
            //            string lastCodeText = MiddlewareRepeatCodeTypes[(int)ProtocolCodeType.LastDataCode];
            //            msgBytes = CodeValuesModifyMethod(msgBytes, lastCodeText, verType);
            //        }

            //        DateTime now = DateTime.Now;
            //        if (verType == typeof(ProtocolV8))
            //        {
            //            msgBytes[2] = Convert.ToByte(i);
            //            msgBytes[7] = Convert.ToByte(now.ToString("yy"));
            //            msgBytes[8] = Convert.ToByte(now.Month);
            //            msgBytes[9] = Convert.ToByte(now.Day);
            //            msgBytes[10] = Convert.ToByte(now.Hour);
            //            msgBytes[11] = Convert.ToByte(now.Minute);
            //            msgBytes[12] = Convert.ToByte(now.Second);
            //        }
            //        else if (verType == typeof(ProtocolV9))
            //        {
            //            string jsonDatas = DeviceBodyMsgBytesToJsonString;
            //            CTRGenericPacket jsonValue = JsonSerializer.Deserialize<CTRGenericPacket>(msgBytes);

            //            string fromDeviceBody = jsonValue.DeviceBase64;

            //            byte[] jsonToByte = Convert.FromBase64String(fromDeviceBody);

            //            jsonToByte[1] = Convert.ToByte(i);
            //            jsonToByte[6] = Convert.ToByte(now.ToString("yy"));
            //            jsonToByte[7] = Convert.ToByte(now.Month);
            //            jsonToByte[8] = Convert.ToByte(now.Day);
            //            jsonToByte[9] = Convert.ToByte(now.Hour);
            //            jsonToByte[10] = Convert.ToByte(now.Minute);
            //            jsonToByte[11] = Convert.ToByte(now.Second);

            //            string toDeviceBody = Convert.ToBase64String(jsonToByte);

            //            DeviceBodyMsgBytesToJsonString = DeviceBodyMsgBytesToJsonString.Replace(fromDeviceBody, toDeviceBody);
            //            msgBytes = Encoding.UTF8.GetBytes(DeviceBodyMsgBytesToJsonString);
            //        }
            //        Thread.Sleep(800);

            //        if (cbBoxRepeatType.SelectedIndex == (int)ProtocolCodeType.LastDataCode) BuildSendMessage(((IEvent)uCtrlVer).EventDatas);
            //        if (cbBoxRepeatType.SelectedIndex == (int)ProtocolCodeType.LastDataCode) Thread.Sleep(500);
            //        if (uCtrlVer.ReeferBody != null) SendMsg(msgBytes, false, true);
            //        Thread.Sleep(500);

            //        BeginInvokeWork(lblRepeatCnt, () =>
            //        {
            //            lblRepeatCnt.Refresh();
            //            lblRepeatCnt.Text = i.ToString();
            //        });
            //    }
            //    SocketClose();
            //}
        }
    }
}
