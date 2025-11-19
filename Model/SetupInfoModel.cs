namespace SimReeferMiddlewareSystemWPF.Model
{
    public class SetupInfoModel
    {
        private int _code = 0;
        private byte _ccpr = 1;
        private ushort _commPeriod = 5;
        private byte _gpsTimeout = 180;
        private byte _gpsStableTime = 30;
        private byte _wireConnTimeOut = 60;
        private byte _retryCount = 3;
        private byte _rcCount = 6;
        private ushort _totalStandbyCount = 0;
        private byte _accelShockUpper = 4;
        private short _setTempLower = 28483;
        private short _setTempUpper = 17657;
        private short _humidLower = 0;
        private ushort _humidUpper = 65535;
        private ushort _stateChangeAlarm = 65535;
        private string _cutOffVoltage = "3.4";

        public int Code
        {
            get { return _code; }
            set
            {
                if (_code != null)
                {
                    _code = value;
                }
            }
        }
        public byte CCPR
        {
            get { return _ccpr; }
            set
            {
                if (_ccpr != null)
                {
                    _ccpr = value;
                }
            }
        }
        public ushort CommPeriod
        {
            get { return _commPeriod; }
            set
            {
                if (_commPeriod != null)
                {
                    _commPeriod = value;
                }
            }
        }
        public byte GpsTimeout
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
        public byte GpsStableTime
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
        public byte WireConnTimeOut
        {
            get { return _wireConnTimeOut; }
            set
            {
                if (_wireConnTimeOut != null)
                {
                    _wireConnTimeOut = value;
                }
            }
        }
        public byte RetryCount
        {
            get { return _retryCount; }
            set
            {
                if (_retryCount != null)
                {
                    _retryCount = value;
                }
            }
        }
        public byte RcCount
        {
            get { return _rcCount; }
            set
            {
                if (_rcCount != null)
                {
                    _rcCount = value;
                }
            }
        }
        public ushort TotalStandbyCount
        {
            get { return _totalStandbyCount; }
            set
            {
                if (_totalStandbyCount != null)
                {
                    _totalStandbyCount = value;
                }
            }
        }
        public byte AccelShockUpper
        {
            get { return _accelShockUpper; }
            set
            {
                if (_accelShockUpper != null)
                {
                    _accelShockUpper = value;
                }
            }
        }
        public short SetTempLower
        {
            get { return _setTempLower; }
            set
            {
                if (_setTempLower != null)
                {
                    _setTempLower = value;
                }
            }
        }
        public short SetTempUpper
        {
            get { return _setTempUpper; }
            set
            {
                if (_setTempUpper != null)
                {
                    _setTempUpper = value;
                }
            }
        }
        public short HumidLower
        {
            get { return _humidLower; }
            set
            {
                if (_humidLower != null)
                {
                    _humidLower = value;
                }
            }
        }
        public ushort HumidUpper
        {
            get { return _humidUpper; }
            set
            {
                if (_humidUpper != null)
                {
                    _humidUpper = value;
                }
            }
        }
        public ushort StateChangeAlarm
        {
            get { return _stateChangeAlarm; }
            set
            {
                if (_stateChangeAlarm != null)
                {
                    _stateChangeAlarm = value;
                }
            }
        }
        public string CutOffVoltage
        {
            get { return _cutOffVoltage; }
            set
            {
                if (_cutOffVoltage != null)
                {
                    _cutOffVoltage = value;
                }
            }
        }
    }
}
