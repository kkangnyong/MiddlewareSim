namespace SimReeferMiddlewareSystemWPF.Model
{
    public class DeviceFirmwareInfoModel
    {
        private string _result = "ok";
        private int _deviceNumber = 7001518;
        private string _deviceType = "CTR-S200B";
        private string _fwVersion = "7.0.6";
        private short _reqType = 2;
        private string _protocolVersion = "1.0.0";
        private string _sequenceType = "H";
        private string _containerType = "S";
        private string _containerNumber = "";
        private string _downloadDate = "";
        private string _extension = "";

        public string Result
        {
            get { return _result; }
            set
            {
                if (_result != null)
                {
                    _result = value;
                }
            }
        }
        public int DeviceNumber
        {
            get { return _deviceNumber; }
            set
            {
                if (_deviceNumber != null)
                {
                    _deviceNumber = value;
                }
            }
        }
        public string DeviceType
        {
            get { return _deviceType; }
            set
            {
                if (_deviceType != null)
                {
                    _deviceType = value;
                }
            }
        }
        public string FwVersion
        {
            get { return _fwVersion; }
            set
            {
                if (_fwVersion != null)
                {
                    _fwVersion = value;
                }
            }
        }
        public short ReqType
        {
            get { return _reqType; }
            set
            {
                if (_reqType != null)
                {
                    _reqType = value;
                }
            }
        }
        public string ProtocolVersion
        {
            get { return _protocolVersion; }
            set
            {
                if (_protocolVersion != null)
                {
                    _protocolVersion = value;
                }
            }
        }
        public string SequenceType
        {
            get { return _sequenceType; }
            set
            {
                if (_sequenceType != null)
                {
                    _sequenceType = value;
                }
            }
        }
        public string ContainerType
        {
            get { return _containerType; }
            set
            {
                if (_containerType != null)
                {
                    _containerType = value;
                }
            }
        }
        public string ContainerNumber
        {
            get { return _containerNumber; }
            set
            {
                if (_containerNumber != null)
                {
                    _containerNumber = value;
                }
            }
        }
        public string DownloadDate
        {
            get { return _downloadDate; }
            set
            {
                if (_downloadDate != null)
                {
                    _downloadDate = value;
                }
            }
        }
        public string Extension
        {
            get { return _extension; }
            set
            {
                if (_extension != null)
                {
                    _extension = value;
                }
            }
        }
    }
}
