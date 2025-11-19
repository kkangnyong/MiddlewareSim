using SimReeferMiddlewareSystemWPF.Inteface;
using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Store;

namespace SimReeferMiddlewareSystemWPF.ViewModel
{
    public class DeviceInfoViewModel : ViewModelBase, IDeviceInfo
    {
        private static DeviceInfoViewModel _instance;
        public static DeviceInfoViewModel Instance { get { if (_instance == null) _instance = new DeviceInfoViewModel(); return _instance; }  }

        private DeviceInfoStore _deviceInfoStore;
        private event EventHandler<UserControlEventArgs> _deviceChanged;

        public DeviceInfoViewModel() { }

        public DeviceInfoViewModel(DeviceInfoStore deviceInfoStore) 
        {
            Instance._deviceInfoStore = deviceInfoStore;
            Instance._deviceChanged += DeviceInfoViewModel_deviceChanged;
            Instance._deviceInfoStore._currentDeviceInfo = new DeviceInfoModel();
        }

        private void DeviceInfoViewModel_deviceChanged(object? sender, UserControlEventArgs e)
        {
            Console.WriteLine(e.OldValue + "" + e.Value);
            if (e == null || string.IsNullOrEmpty(e.Name))
            {
                return;
            }

            DeviceInfoModel deviceInfoModel = Instance._deviceInfoStore._currentDeviceInfo;

            if (e.Name.Equals(nameof(Code)))
            {
                deviceInfoModel.Code = (char)e.Value;
            }
            else
            if (e.Name.Equals(nameof(DeviceNumber)))
            {
                deviceInfoModel.DeviceNumber = (int)e.Value;
            }
            else
            if (e.Name.Equals(nameof(Major)))
            {
                deviceInfoModel.Major = (byte)e.Value;
            }
            else
            if (e.Name.Equals(nameof(Minor)))
            {
                deviceInfoModel.Minor = (byte)e.Value;
            }
            else
            if (e.Name.Equals(nameof(Revision)))
            {
                deviceInfoModel.Revision = (byte)e.Value;
            }

            Instance._deviceInfoStore._currentDeviceInfo = deviceInfoModel;
        }

        private void OnChanged(UserControlEventArgs args)
        {
            if (Instance._deviceChanged != null)
            {
                Instance._deviceChanged(this, args);
            }
        }

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
                    char oldValue = _code;
                    _code = value;
                    OnPropertyChanged();
                    Instance.OnChanged(new UserControlEventArgs(nameof(Code), oldValue, value));
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
                    int oldValue = _deviceNumber;
                    _deviceNumber = value;
                    OnPropertyChanged();
                    Instance.OnChanged(new UserControlEventArgs(nameof(DeviceNumber), oldValue, value));
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
                    byte oldValue = _major;
                    _major = value;
                    OnPropertyChanged();
                    Instance.OnChanged(new UserControlEventArgs(nameof(Major), oldValue, value));
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
                    byte oldValue = _minor;
                    _minor = value;
                    OnPropertyChanged();
                    Instance.OnChanged(new UserControlEventArgs(nameof(Minor), oldValue, value));
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
                    byte oldValue = _revision;
                    _revision = value;
                    OnPropertyChanged();
                    Instance.OnChanged(new UserControlEventArgs(nameof(Revision), oldValue, value));
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
                }
            }
        }
    }
}
