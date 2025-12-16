namespace SimReeferMiddlewareSystemWPF.Model
{
    public class ServerConnectionModel
    {
        private string _ip { get; set; } = "192.168.10.14";//"dev.swinnus.net";
        private ushort _port { get; set; } = 14000;
        private string _protocolVersion { get; set; } = "0.8.0.0";

        public string IP
        {
            get { return _ip; }
            set
            {
                if (_ip != null)
                    _ip = value;
            }
        }

        public ushort Port
        {
            get { return _port; }
            set
            {
                if (_port != null)
                    _port = value;
            }
        }

        public string ProtocolVersion
        {
            get { return _protocolVersion; }
            set
            {
                if (_protocolVersion != null)
                    _protocolVersion = value;
            }
        }
    }
}
