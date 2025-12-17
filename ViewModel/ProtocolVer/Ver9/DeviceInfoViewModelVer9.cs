using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Store;

namespace SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver9
{
    public class DeviceInfoViewModelVer9 : ViewModelBase
    {
        private static DeviceInfoViewModelVer9 _instance;
        public DeviceInfoViewModelVer9 Instance { get { if (_instance == null) _instance = new DeviceInfoViewModelVer9(); return _instance; } }

        private DeviceBodyStore _deviceBodyStore;

        private DeviceInfoStore _deviceInfoStore;

        private DeviceInfoModel _deviceInfoModel;
        public DeviceInfoModel DeviceInfoModel { get { if (_deviceInfoModel == null) _deviceInfoModel = Instance._deviceInfoStore._currentDeviceInfo = new DeviceInfoModel(); return _deviceInfoModel; } }
        private List<bool> _isChargeList { get; set; } = new List<bool>() { false, true };

        public DeviceInfoViewModelVer9() { }

        public DeviceInfoViewModelVer9(DeviceInfoStore deviceInfoStore, DeviceBodyStore deviceBodyStore)
        {
            _instance = this;
            _deviceInfoStore = deviceInfoStore;
            _deviceBodyStore = deviceBodyStore;
        }

        public List<bool> ChargeList
        {
            get { return _isChargeList; }
            set
            {
                if (_isChargeList != null)
                {
                    _isChargeList = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Code
        {
            get { return DeviceInfoModel.Code; }
            set
            {
                if (DeviceInfoModel.Code != null)
                {
                    DeviceInfoModel.Code = value;
                    OnPropertyChanged();
                }
            }
        }
        public int DeviceNumber
        {
            get { return DeviceInfoModel.DeviceNumber; }
            set
            {
                if (DeviceInfoModel.DeviceNumber != null)
                {
                    DeviceInfoModel.DeviceNumber = value;
                    OnPropertyChanged();
                    Instance._deviceBodyStore.CurrentDeviceBodyChanged?.Invoke(new DeviceBodyModel() { DeviceNumber = value });
                }
            }
        }
        public byte Major
        {
            get { return DeviceInfoModel.Major; }
            set
            {
                if (DeviceInfoModel.Major != null)
                {
                    DeviceInfoModel.Major = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte Minor
        {
            get { return DeviceInfoModel.Minor; }
            set
            {
                if (DeviceInfoModel.Minor != null)
                {
                    DeviceInfoModel.Minor = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte Revision
        {
            get { return DeviceInfoModel.Revision; }
            set
            {
                if (DeviceInfoModel.Revision != null)
                {
                    DeviceInfoModel.Revision = value;
                    OnPropertyChanged();
                }
            }
        }
        public int DbgIdCode
        {
            get { return DeviceInfoModel.DbgIdCode; }
            set
            {
                if (DeviceInfoModel.DbgIdCode != null)
                {
                    DeviceInfoModel.DbgIdCode = value;
                    OnPropertyChanged();
                }
            }
        }
        public int PwrCSR
        {
            get { return DeviceInfoModel.PwrCSR; }
            set
            {
                if (DeviceInfoModel.PwrCSR != null)
                {
                    DeviceInfoModel.PwrCSR = value;
                    OnPropertyChanged();
                }
            }
        }
        public int RccCSR
        {
            get { return DeviceInfoModel.RccCSR; }
            set
            {
                if (DeviceInfoModel.RccCSR != null)
                {
                    DeviceInfoModel.RccCSR = value;
                    OnPropertyChanged();
                }
            }
        }
        public int FlashSR
        {
            get { return DeviceInfoModel.FlashSR; }
            set
            {
                if (DeviceInfoModel.FlashSR != null)
                {
                    DeviceInfoModel.FlashSR = value;
                    OnPropertyChanged();
                }
            }
        }
        public int FlashOBR
        {
            get { return DeviceInfoModel.FlashOBR; }
            set
            {
                if (DeviceInfoModel.FlashOBR != null)
                {
                    DeviceInfoModel.FlashOBR = value;
                    OnPropertyChanged();
                }
            }
        }
        public int LwdgSR
        {
            get { return DeviceInfoModel.LwdgSR; }
            set
            {
                if (DeviceInfoModel.LwdgSR != null)
                {
                    DeviceInfoModel.LwdgSR = value;
                    OnPropertyChanged();
                }
            }
        }
        public short CurStandbyCount
        {
            get { return DeviceInfoModel.CurStandbyCount; }
            set
            {
                if (DeviceInfoModel.CurStandbyCount != null)
                {
                    DeviceInfoModel.CurStandbyCount = value;
                    OnPropertyChanged();
                }
            }
        }
        public int LastGeofenceIndex
        {
            get { return DeviceInfoModel.LastGeofenceIndex; }
            set
            {
                if (DeviceInfoModel.LastGeofenceIndex != null)
                {
                    DeviceInfoModel.LastGeofenceIndex = value;
                    OnPropertyChanged();
                }
            }
        }
        public string UsimIMSI
        {
            get { return DeviceInfoModel.UsimIMSI; }
            set
            {
                if (DeviceInfoModel.UsimIMSI != null)
                {
                    DeviceInfoModel.UsimIMSI = value;
                    OnPropertyChanged();
                }
            }
        }
        public short Rssi
        {
            get { return DeviceInfoModel.Rssi; }
            set
            {
                if (DeviceInfoModel.Rssi != null)
                {
                    DeviceInfoModel.Rssi = value;
                    OnPropertyChanged();
                }
            }
        }
        public int MCCMNC
        {
            get { return DeviceInfoModel.MCCMNC; }
            set
            {
                if (DeviceInfoModel.MCCMNC != null)
                {
                    DeviceInfoModel.MCCMNC = value;
                    OnPropertyChanged();
                }
            }
        }
        public short Lac
        {
            get { return DeviceInfoModel.Lac; }
            set
            {
                if (DeviceInfoModel.Lac != null)
                {
                    DeviceInfoModel.Lac = value;
                    OnPropertyChanged();
                }
            }
        }
        public int CellID
        {
            get { return DeviceInfoModel.CellID; }
            set
            {
                if (DeviceInfoModel.CellID != null)
                {
                    DeviceInfoModel.CellID = value;
                    OnPropertyChanged();
                }
            }
        }
        public string WireType
        {
            get { return DeviceInfoModel.WireType; }
            set
            {
                if (DeviceInfoModel.WireType != null)
                {
                    DeviceInfoModel.WireType = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ActiveBand
        {
            get { return DeviceInfoModel.ActiveBand; }
            set
            {
                if (DeviceInfoModel.ActiveBand != null)
                {
                    DeviceInfoModel.ActiveBand = value;
                    OnPropertyChanged();
                }
            }
        }
        public string CellOperator
        {
            get { return DeviceInfoModel.CellOperator; }
            set
            {
                if (DeviceInfoModel.CellOperator != null)
                {
                    DeviceInfoModel.CellOperator = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte Ccpr
        {
            get { return DeviceInfoModel.Ccpr; }
            set
            {
                if (DeviceInfoModel.Ccpr != null)
                {
                    DeviceInfoModel.Ccpr = value;
                    OnPropertyChanged();
                }
            }
        }
        public ushort CommPeriod
        {
            get { return DeviceInfoModel.CommPeriod; }
            set
            {
                if (DeviceInfoModel.CommPeriod != null)
                {
                    DeviceInfoModel.CommPeriod = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte GpsTimeout
        {
            get { return DeviceInfoModel.GpsTimeout; }
            set
            {
                if (DeviceInfoModel.GpsTimeout != null)
                {
                    DeviceInfoModel.GpsTimeout = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte GpsStableTime
        {
            get { return DeviceInfoModel.GpsStableTime; }
            set
            {
                if (DeviceInfoModel.GpsStableTime != null)
                {
                    DeviceInfoModel.GpsStableTime = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte WireConnTimeout
        {
            get { return DeviceInfoModel.WireConnTimeout; }
            set
            {
                if (DeviceInfoModel.WireConnTimeout != null)
                {
                    DeviceInfoModel.WireConnTimeout = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte RetryCount
        {
            get { return DeviceInfoModel.RetryCount; }
            set
            {
                if (DeviceInfoModel.RetryCount != null)
                {
                    DeviceInfoModel.RetryCount = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte RcCount
        {
            get { return DeviceInfoModel.RcCount; }
            set
            {
                if (DeviceInfoModel.RcCount != null)
                {
                    DeviceInfoModel.RcCount = value;
                    OnPropertyChanged();
                }
            }
        }
        public ushort TotalStandbyCount
        {
            get { return DeviceInfoModel.TotalStandbyCount; }
            set
            {
                if (DeviceInfoModel.TotalStandbyCount != null)
                {
                    DeviceInfoModel.TotalStandbyCount = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte AccelShockUpper
        {
            get { return DeviceInfoModel.AccelShockUpper; }
            set
            {
                if (DeviceInfoModel.AccelShockUpper != null)
                {
                    DeviceInfoModel.AccelShockUpper = value;
                    OnPropertyChanged();
                }
            }
        }
        public ushort SetTempLower
        {
            get { return DeviceInfoModel.SetTempLower; }
            set
            {
                if (DeviceInfoModel.SetTempLower != null)
                {
                    DeviceInfoModel.SetTempLower = value;
                    OnPropertyChanged();
                }
            }
        }
        public ushort SetTempUpper
        {
            get { return DeviceInfoModel.SetTempUpper; }
            set
            {
                if (DeviceInfoModel.SetTempUpper != null)
                {
                    DeviceInfoModel.SetTempUpper = value;
                    OnPropertyChanged();
                }
            }
        }
        public ushort HumidLower
        {
            get { return DeviceInfoModel.HumidLower; }
            set
            {
                if (DeviceInfoModel.HumidLower != null)
                {
                    DeviceInfoModel.HumidLower = value;
                    OnPropertyChanged();
                }
            }
        }
        public ushort HumidUpper
        {
            get { return DeviceInfoModel.HumidUpper; }
            set
            {
                if (DeviceInfoModel.HumidUpper != null)
                {
                    DeviceInfoModel.HumidUpper = value;
                    OnPropertyChanged();
                }
            }
        }
        public ushort StateChangedAlarm
        {
            get { return DeviceInfoModel.StateChangedAlarm; }
            set
            {
                if (DeviceInfoModel.StateChangedAlarm != null)
                {
                    DeviceInfoModel.StateChangedAlarm = value;
                    OnPropertyChanged();
                }
            }
        }
        public string CutOffVoltage
        {
            get { return DeviceInfoModel.CutOffVoltage; }
            set
            {
                if (DeviceInfoModel.CutOffVoltage != null)
                {
                    DeviceInfoModel.CutOffVoltage = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Voltage
        {
            get { return DeviceInfoModel.Voltage; }
            set
            {
                if (DeviceInfoModel.Voltage != null)
                {
                    DeviceInfoModel.Voltage = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsCharging
        {
            get { return DeviceInfoModel.IsCharging; }
            set
            {
                if (DeviceInfoModel.IsCharging != null)
                {
                    DeviceInfoModel.IsCharging = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
