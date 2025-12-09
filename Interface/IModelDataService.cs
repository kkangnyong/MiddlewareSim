using SimReeferMiddlewareSystemWPF.Service;

namespace SimReeferMiddlewareSystemWPF.Interface
{
    public interface IModelDataService
    {
        void InitGenericData();
        void InitSensorData();
        void SetDataValues(List<byte[]> dataList); 
        void SetDataByteValues(List<byte[]> dataList, short type);
        void SetDataJsonValues(List<byte[]> dataList, short type, short? code = (short)CodeType.LastData);
        string ConvertToByteString(string msg, ushort length, bool isString);
        byte[] GetStringsToByteArray(string msg, ushort length = 1, bool isString = false, bool isSequence = false);
        List<byte[]>? _dataValuesList { get; set; }
        int _totalDataBytesLength { get; set; }
        byte[]? _resultDataValuesToBytes { get; set; }
        string _dataValuesToJsonString { get; set; }
        List<List<byte[]>> _sensorBodyList { get; set; }
    }
}
