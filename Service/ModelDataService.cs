using SimReeferMiddlewareSystemWPF.Interface;
using System.Text;
using System.Text.RegularExpressions;

namespace SimReeferMiddlewareSystemWPF.Service
{
    public class ModelDataService : IModelDataService
    {
        public List<byte[]>? _dataValuesList { get; set; }
        public int _totalDataBytesLength = 0;

        public void SetDataValues(List<byte[]> dataList)
        {
            if (_dataValuesList != null && _dataValuesList.Count > 0)
            {
                _dataValuesList.Clear();
                _totalDataBytesLength = 0;
            }

            _dataValuesList?.AddRange(dataList);
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
