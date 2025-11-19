namespace SimReeferMiddlewareSystemWPF.Store
{
    public class UserControlEventArgs : EventArgs
    {
        public List<byte[]>? DataBytesList { get; private set; }
        public int TotalDataBytesLength { get; private set; }
        public string? DataBytesToString { get; private set; }
        public bool IsLastData { get; private set; }
        public string Name { get; private set; }
        public object OldValue { get; private set; }
        public object Value { get; private set; }
        public UserControlEventArgs(List<byte[]> dataBytesList, int totalDataBytesLength, byte code = 0) 
        { 
            DataBytesList = dataBytesList;
            TotalDataBytesLength = totalDataBytesLength;
            if (code > 0) IsLastData = ((code & 0x10) == 0x10);
        }

        //public UserControlEventArgs(string dataBytesToString, int totalDataBytesLength, byte code = 0)
        //{
        //    DataBytesToString = dataBytesToString;
        //    TotalDataBytesLength = totalDataBytesLength;
        //    if (code > 0) IsLastData = ((code & 0x10) == 0x10);
        //}

        public UserControlEventArgs(string name, object oldValue, object value)
        {
            Name = name;
            OldValue = oldValue;
            Value = value;
        }
    }
}
