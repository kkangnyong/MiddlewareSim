namespace SimReeferMiddlewareSystemWPF.Interface
{
    public interface ITcpSocketService
    {
        void Connection(string _ip, ushort _port);
        void Disconnection();
        bool SendMsg(byte[] messages, bool isVer, bool isAddCrc);
    }
}
