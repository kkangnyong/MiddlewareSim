namespace SimReeferMiddlewareSystemWPF.Model
{
    public class DeviceInfoModel
    {
        private char _code;
        private int _deviceNumber = 6002032;
        private byte _major = 3;
        private byte _minor = 5;
        private byte _revision = 19;
        private int _dbgIdCode = 272131126;
        private int _pwrCSR = 8;
        private int _rccCSR = 474022658;
        private int _flashSR = 14;
        private int _flashOBR = 16253098;
        private int _lwdgSR = 0;
        private short _curStandbyCount = 0;
        private int _lastGeofenceIndex = -1;
        private string _usimIMSI = "234500084385731";
        private short _rssi = -55;
        private string _iccid = "23450008438731";
        private int _mccmnc = 45008;
        private short _lac = 3157;
        private int _cellID = 0;
        private string _wireType = "FDD LTE";
        private string _activeBand = "LTE BAND 3";
        private string _cellOperator = "KT ONOMONDO";
        private byte _ccpr = 1;
        private ushort _commPeriod = 5;
        private byte _gpsTimeout = 180;
        private byte _gpsStableTime = 30;
        private byte _wireConnTimeout = 60;
        private byte _retryCount = 3;
        private byte _rcCount = 6;
        private ushort _totalStandbyCount = 0;
        private byte _accelShockUpper = 4;
        private ushort _setTempLower = 28483;
        private ushort _setTempUpper = 17657;
        private ushort _humidLower = 0;
        private ushort _humidUpper = 65535;
        private ushort _stateChangedAlarm = 65535;
        private string _cutOffVoltage = "3.40";
        private string _voltage = "4.19";
        private bool _isCharging = true;

        public char Code
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
        public byte Major
        {
            get { return _major; }
            set
            {
                if (_major != null)
                {
                    _major = value;
                }
            }
        }
        public byte Minor
        {
            get { return _minor; }
            set
            {
                if (_minor != null)
                {
                    _minor = value;
                }
            }
        }
        public byte Revision
        {
            get { return _revision; }
            set
            {
                if (_revision != null)
                {
                    _revision = value;
                }
            }
        }
        public int DbgIdCode
        {
            get { return _dbgIdCode; }
            set
            {
                if (_dbgIdCode != null)
                {
                    _dbgIdCode = value;
                }
            }
        }
        public int PwrCSR
        {
            get { return _pwrCSR; }
            set
            {
                if (_pwrCSR != null)
                {
                    _pwrCSR = value;
                }
            }
        }
        public int RccCSR
        {
            get { return _rccCSR; }
            set
            {
                if (_rccCSR != null)
                {
                    _rccCSR = value;
                }
            }
        }
        public int FlashSR
        {
            get { return _flashSR; }
            set
            {
                if (_flashSR != null)
                {
                    _flashSR = value;
                }
            }
        }
        public int FlashOBR
        {
            get { return _flashOBR; }
            set
            {
                if (_flashOBR != null)
                {
                    _flashOBR = value;
                }
            }
        }
        public int LwdgSR
        {
            get { return _lwdgSR; }
            set
            {
                if (_lwdgSR != null)
                {
                    _lwdgSR = value;
                }
            }
        }
        public short CurStandbyCount
        {
            get { return _curStandbyCount; }
            set
            {
                if (_curStandbyCount != null)
                {
                    _curStandbyCount = value;
                }
            }
        }
        public int LastGeofenceIndex
        {
            get { return _lastGeofenceIndex; }
            set
            {
                if (_lastGeofenceIndex != null)
                {
                    _lastGeofenceIndex = value;
                }
            }
        }
        public string UsimIMSI
        {
            get { return _usimIMSI; }
            set
            {
                if (_usimIMSI != null)
                {
                    _usimIMSI = value;
                }
            }
        }
        public short Rssi
        {
            get { return _rssi; }
            set
            {
                if (_rssi != null)
                {
                    _rssi = value;
                }
            }
        }
        public string Iccid
        {
            get { return _iccid; }
            set
            {
                if (_iccid != null)
                {
                    _iccid = value;
                }
            }
        }
        public int MCCMNC
        {
            get { return _mccmnc; }
            set
            {
                if (_mccmnc != null)
                {
                    _mccmnc = value;
                }
            }
        }
        public short Lac
        {
            get { return _lac; }
            set
            {
                if (_lac != null)
                {
                    _lac = value;
                }
            }
        }
        public int CellID
        {
            get { return _cellID; }
            set
            {
                if (_cellID != null)
                {
                    _cellID = value;
                }
            }
        }
        public string WireType
        {
            get { return _wireType; }
            set
            {
                if (_wireType != null)
                {
                    _wireType = value;
                }
            }
        }
        public string ActiveBand
        {
            get { return _activeBand; }
            set
            {
                if (_activeBand != null)
                {
                    _activeBand = value;
                }
            }
        }
        public string CellOperator
        {
            get { return _cellOperator; }
            set
            {
                if (_cellOperator != null)
                {
                    _cellOperator = value;
                }
            }
        }
        public byte Ccpr
        {
            get { return _ccpr; }
            set
            {
                if (_ccpr != null)
                {
                    _deviceNumber = value;
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
        public byte WireConnTimeout
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
        public ushort SetTempLower
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
        public ushort SetTempUpper
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
        public ushort HumidLower
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
        public ushort StateChangedAlarm
        {
            get { return _stateChangedAlarm; }
            set
            {
                if (_stateChangedAlarm != null)
                {
                    _stateChangedAlarm = value;
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
        public string Voltage
        {
            get { return _voltage; }
            set
            {
                if (_voltage != null)
                {
                    _voltage = value;
                }
            }
        }
        public bool IsCharging
        {
            get { return _isCharging; }
            set
            {
                if (_isCharging != null)
                {
                    _isCharging = value;
                }
            }
        }
    }
}
