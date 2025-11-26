using SimReeferMiddlewareSystemWPF.Interface;
using System.Text;
using System.Text.RegularExpressions;

namespace SimReeferMiddlewareSystemWPF.Service
{
    public class ModelDataService : IModelDataService
    {
        public List<byte[]>? _dataValuesList { get; set; }
        public string _dataValuesToJsonString { get; set; }
        public List<List<byte[]>> _sensorBodyList { get; set; }

        public int _totalDataBytesLength { get; set; } = 0;
        private byte[]? _tempDataValuesToBytes { get; set; }
        public byte[]? _resultDataValuesToBytes { get; set; }

        public void InitGenericData()
        {
            if (_dataValuesList != null && _dataValuesList.Count > 0)
            {
                _dataValuesList.Clear();
                _totalDataBytesLength = 0;
            }
            if (_sensorBodyList != null && _sensorBodyList.Count > 0)
            {
                _sensorBodyList.Clear();
            }
        }

        public void SetDataValues(List<byte[]> dataList)
        {
            _dataValuesList?.AddRange(dataList);
        }

        public void SetDataByteValues(List<byte[]> dataList, short type)
        {
            _dataValuesList?.AddRange(dataList);

            if (type == (short)DataType.Device)
            {
                if (_resultDataValuesToBytes != null && _resultDataValuesToBytes.Length > 0)
                {
                    _resultDataValuesToBytes = null;
                }
                _tempDataValuesToBytes = new byte[_totalDataBytesLength];

                int index = 0;
                foreach (byte[] dataBytes in _dataValuesList)
                {
                    Array.Copy(dataBytes, 0, _tempDataValuesToBytes, index, dataBytes.Length);
                    index += dataBytes.Length;
                }
            }
            else
            {
                if (_tempDataValuesToBytes == null || _tempDataValuesToBytes.Length <= 0)
                {
                    return;
                }

                int index = 0;
                _resultDataValuesToBytes = new byte[_totalDataBytesLength + _tempDataValuesToBytes.Length];

                Array.Copy(_tempDataValuesToBytes, 0, _resultDataValuesToBytes, index, _tempDataValuesToBytes.Length);

                index = _tempDataValuesToBytes.Length;

                foreach (byte[] dataBytes in _dataValuesList)
                {
                    Array.Copy(dataBytes, 0, _resultDataValuesToBytes, index, dataBytes.Length);
                    index += dataBytes.Length;
                }
                _tempDataValuesToBytes = null;
            }
        }

        public void SetDataJsonValues(List<byte[]> dataList, short type, short? code = (short)CodeType.LastData)
        {
            if (type == (short)DataType.Sensor)
            {
                if (dataList.Count <= 0)
                {
                    string replaceText = _dataValuesToJsonString;
                    _dataValuesToJsonString = replaceText.Remove(replaceText.Length - 1, 1).Insert(replaceText.Length - 1, "}");
                    return;
                }

                _dataValuesToJsonString += " \"sen\": [";
                byte[] resultBytes = new byte[_totalDataBytesLength];
                byte[] tempBytes = resultBytes;
                int index = 0;
                foreach (List<byte[]> dataBytes in _sensorBodyList)
                {
                    int dataLength = 0;
                    int tempByteindex = 0;
                    foreach (byte[] data in dataBytes)
                    {
                        Array.Copy(data, 0, resultBytes, dataLength, data.Length);
                        dataLength += data.Length;
                    }
                    foreach (byte b in resultBytes)
                    {
                        if (b > 0)
                        {
                            tempBytes[tempByteindex++] = b;
                        }
                    }
                    Array.Resize(ref tempBytes, tempByteindex);
                    resultBytes = tempBytes;

                    _dataValuesToJsonString += "{\"d\": \"" + $"{Convert.ToBase64String(resultBytes)}\", \"i\": {index}" + ", \"t\": 1}";
                    if (index < _sensorBodyList.Count - 1)
                    {
                        _dataValuesToJsonString += ", ";
                    }
                    index++;
                }
                _dataValuesToJsonString += "]}";
            }
            else
            {
                _dataValuesList?.AddRange(dataList);

                byte[] resultBytes = new byte[_totalDataBytesLength];
                int index = 0;
                foreach (byte[] dataBytes in _dataValuesList)
                {
                    Array.Copy(dataBytes, 0, resultBytes, index, dataBytes.Length);
                    index += dataBytes.Length;
                }

                if (type == (short)DataType.Device)
                {
                    _dataValuesToJsonString = "{\"cod\": " + $"{code}" + ", \"dev\": " + $"\"{Convert.ToBase64String(resultBytes)}\"";
                }
                else if (type == (short)DataType.Reefer)
                {
                    _dataValuesToJsonString += ", \"ref\": " + $"\"{Convert.ToBase64String(resultBytes)}\"" + ",";
                }
            }
        }

        public string ConvertToByteString(string msg, ushort length, bool isString)
        {
            if (string.IsNullOrEmpty(msg)) return string.Empty;

            int value = 0;
            if (!int.TryParse(msg, out value)) value = -1;

            byte[] hexArray = BitConverter.GetBytes(value).Reverse().ToArray();

            if (isString && value == -1)
            {
                hexArray = new byte[length];
                byte[] hexArraytemp = Encoding.ASCII.GetBytes(msg);
                Array.Copy(hexArraytemp, 0, hexArray, 0, hexArraytemp.Length);
            }
            else if (msg.Contains(".") || msg.Contains(","))
            {
                List<byte> tempHexArray = new List<byte>();
                string[] parts = msg.Split(new string[] { ".", "," }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string part in parts)
                {
                    tempHexArray.Add(Convert.ToByte(part));
                }
                hexArray = new byte[length];
                Array.Copy(tempHexArray.ToArray(), 0, hexArray, 0, tempHexArray.ToArray().Length);
            }
            int startIndex = length > 2 ? 0 : hexArray.Length - length; ;
            return BitConverter.ToString(hexArray, startIndex, length);// string.Concat(BitConverter.ToString(hexArray).Where(x => !Char.IsPunctuation(x)));
        }

        public byte[] GetStringsToByteArray(string msg, ushort length = 1, bool isString = false, bool isSequence = false)
        {
            try
            {
                string concatMsg = isSequence ? string.Concat(msg.Where(x => !Char.IsWhiteSpace(x))) : string.Concat(ConvertToByteString(msg, length, isString).Where(x => !Char.IsWhiteSpace(x)));

                //Command 명령 전송 시
                if (Regex.IsMatch(concatMsg, @"^[a-z]*$"))
                {
                    concatMsg = concatMsg.ToLower().Trim();
                    byte[] msgEncodingBytes = Encoding.Default.GetBytes(msg);

                    _totalDataBytesLength = msgEncodingBytes.Length;
                    return msgEncodingBytes;
                }

                string[] strings = concatMsg.Split(new string[] { ",", ".", "\t", "-", " " }, StringSplitOptions.RemoveEmptyEntries);
                byte[] msgBytes = new byte[strings.Length];

                for (int i = 0; i < strings.Length; i++)
                {
                    string txt = strings[i];
                    byte[] res = Enumerable.Range(0, txt.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(txt.Substring(x, 2), 16)).ToArray();
                    msgBytes[i] = res[0];
                }
                _totalDataBytesLength += msgBytes.Length;
                return msgBytes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }
    }
}
