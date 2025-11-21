namespace SimReeferMiddlewareSystemWPF.Interface
{
    public interface ITcpSocketService
    {
        void Connection(string _ip, ushort _port);
        void Disconnection();
        bool SendMsg(byte[] messages, bool isVer, bool isAddCrc);
        Action? SocketAsyncConnected { get; set; }
        Action? SocketAsyncDisconnected { get; set; }
        Action<string>? SocketAsyncError { get; set; }
    }
}
