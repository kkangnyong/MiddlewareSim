namespace SimReeferMiddlewareSystemWPF.Interface
{
    public interface IModelDataService
    {
        void SetDataValues(List<byte[]> dataList);
        string ConvertToByteString(string msg, ushort length, bool isString);
        byte[] GetStringsToByteArray(string msg, ushort length = 1, bool isString = false, bool isSequence = false);
        List<byte[]>? _dataValuesList { get; set; }
    }
}
