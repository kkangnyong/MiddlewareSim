namespace SimReeferMiddlewareSystemWPF.Interface
{
    public interface ITcpSocketService
    {
        void Connection(string _ip, ushort _port);
        void Disconnection();
        bool SendMsg(byte[] messages, bool isVer, bool isAddCrc);
        bool BuildSendMessage(int totalDataBytesLength, List<byte[]> dataBytesList);
        void RepeatDataSendOption(IProtocolVer ownVer, IModelDataService modelData, bool isRepeat, int repeatCnt, short code);
        Action? SocketAsyncConnected { get; set; }
        Action? SocketAsyncDisconnected { get; set; }
        Action<string>? SocketAsyncError { get; set; }
        Action<byte[]>? NoSynchronizationSetupInfo { get; set; }
        Action<IDictionary<string, string>, byte[]>? SynchronizationSetupInfo { get; set; }
        Action<byte[]>? RecievedByteToString { get; set; }
    }
}
