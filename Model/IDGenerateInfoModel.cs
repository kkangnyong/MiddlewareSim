namespace SimReeferMiddlewareSystemWPF.Model
{
    public class IDGenerateInfoModel
    {
        private string _apn = "onomondo";
        private string _deviceType = "CTR-S200B";
        private string _hwVer = "9.9.9";
        private string _mobileIMEI = "862771047956522";
        private byte _requestType = 0;
        private string _swVer = "1.5.0";
        private string _mcu = "STM32L152VE";
        private string _mobile = "";
        private short _period = 720;
        private string _usim = "234500084386601";
        private short _gpsTimeout = 90;
        private short _gpsStableTime = 30;
        private short _wireConnTimeout = 120;
        private short _commRetryCount = 3;
        private byte _shockUpper = 9;

        public string APN
        {
            get { return _apn; }
            set
            {
                if (_apn != null)
                {
                    _apn = value;
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
        public string HwVer
        {
            get { return _hwVer; }
            set
            {
                if (_hwVer != null)
                {
                    _hwVer = value;
                }
            }
        }
        public string MobileIMEI
        {
            get { return _mobileIMEI; }
            set
            {
                if (_mobileIMEI != null)
                {
                    _mobileIMEI = value;
                }
            }
        }
        public byte RequestType
        {
            get { return _requestType; }
            set
            {
                if (_requestType != null)
                {
                    _requestType = value;
                }
            }
        }
        public string SwVer
        {
            get { return _swVer; }
            set
            {
                if (_swVer != null)
                {
                    _swVer = value;
                }
            }
        }
        public string Mcu
        {
            get { return _mcu; }
            set
            {
                if (_mcu != null)
                {
                    _mcu = value;
                }
            }
        }
        public string Mobile
        {
            get { return _mobile; }
            set
            {
                if (_mobile != null)
                {
                    _mobile = value;
                }
            }
        }
        public short Period
        {
            get { return _period; }
            set
            {
                if (_period != null)
                {
                    _period = value;
                }
            }
        }
        public string Usim
        {
            get { return _usim; }
            set
            {
                if (_usim != null)
                {
                    _usim = value;
                }
            }
        }
        public short GpsTimeout
        {
            get { return _gpsTimeout; }
            set
            {
                if (_gpsTimeout != null)
                {
                    _gpsTimeout = value;
                }
            }
        }
        public short GpsStableTime
        {
            get { return _gpsStableTime; }
            set
            {
                if (_gpsStableTime != null)
                {
                    _gpsStableTime = value;
                }
            }
        }
        public short WireConnTimeout
        {
            get { return _wireConnTimeout; }
            set
            {
                if (_wireConnTimeout != null)
                {
                    _wireConnTimeout = value;
                }
            }
        }
        public short CommRetryCount
        {
            get { return _commRetryCount; }
            set
            {
                if (_commRetryCount != null)
                {
                    _commRetryCount = value;
                }
            }
        }
        public byte ShockUpper
        {
            get { return _shockUpper; }
            set
            {
                if (_shockUpper != null)
                {
                    _shockUpper = value;
                }
            }
        }
    }
}
