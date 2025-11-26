using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Service;
using SimReeferMiddlewareSystemWPF.Store;

namespace SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver8
{
    public class DeviceBodyViewModelVer8 : ViewModelBase
    {
        private static DeviceBodyViewModelVer8 _instance;
        public DeviceBodyViewModelVer8 Instance { get { if (_instance == null) _instance = new DeviceBodyViewModelVer8(); return _instance; } }

        private DeviceBodyStore _deviceBodyStore;

        private DeviceBodyModel _deviceBodyModel;
        public DeviceBodyModel DeviceBodyModel { get { if (_deviceBodyModel == null) _deviceBodyModel = Instance._deviceBodyStore._currentDeviceBody = new DeviceBodyModel(); return _deviceBodyModel; } }

        private List<short> _codeList { get; set; } = new List<short>() { (short)CodeType.CommonData, (short)CodeType.LastData };

        public DeviceBodyViewModelVer8() { }

        public DeviceBodyViewModelVer8(DeviceBodyStore deviceBodyStore)
        {
            _instance = this;
            Instance._deviceBodyStore = deviceBodyStore;
        }

        public List<short> CodeList
        {
            get { return _codeList; }
            set
            {
                if (_codeList != null)
                {
                    _codeList = value;
                    OnPropertyChanged();
                }
            }
        }

        public short? Code
        {
            get { return DeviceBodyModel.Code; }
            set
            {
                if (DeviceBodyModel.Code != null)
                {
                    DeviceBodyModel.Code = value;
                    OnPropertyChanged();
                }
            }
        }

        public ushort Index
        {
            get { return DeviceBodyModel.Index; }
            set
            {
                if (DeviceBodyModel.Index != null)
                {
                    DeviceBodyModel.Index = value;
                    OnPropertyChanged();
                }
            }
        }
        public int DeviceNumber
        {
            get { return DeviceBodyModel.DeviceNumber; }
            set
            {
                if (DeviceBodyModel.DeviceNumber != null)
                {
                    DeviceBodyModel.DeviceNumber = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte Year
        {
            get { return DeviceBodyModel.Year; }
            set
            {
                if (DeviceBodyModel.Year != null)
                {
                    DeviceBodyModel.Year = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte Month
        {
            get { return DeviceBodyModel.Month; }
            set
            {
                if (DeviceBodyModel.Month != null)
                {
                    DeviceBodyModel.Month = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte Day
        {
            get { return DeviceBodyModel.Day; }
            set
            {
                if (DeviceBodyModel.Day != null)
                {
                    DeviceBodyModel.Day = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte Hour
        {
            get { return DeviceBodyModel.Hour; }
            set
            {
                if (DeviceBodyModel.Hour != null)
                {
                    DeviceBodyModel.Hour = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte Min
        {
            get { return DeviceBodyModel.Min; }
            set
            {
                if (DeviceBodyModel.Min != null)
                {
                    DeviceBodyModel.Min = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte Second
        {
            get { return DeviceBodyModel.Second; }
            set
            {
                if (DeviceBodyModel.Second != null)
                {
                    DeviceBodyModel.Second = value;
                    OnPropertyChanged();
                }
            }
        }
        public char GPSEnable
        {
            get { return DeviceBodyModel.GPSEnable; }
            set
            {
                if (DeviceBodyModel.GPSEnable != null)
                {
                    DeviceBodyModel.GPSEnable = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte LatDegree
        {
            get { return DeviceBodyModel.LatDegree; }
            set
            {
                if (DeviceBodyModel.LatDegree != null)
                {
                    DeviceBodyModel.LatDegree = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte LatDegreePoint1
        {
            get { return DeviceBodyModel.LatDegreePoint1; }
            set
            {
                if (DeviceBodyModel.LatDegreePoint1 != null)
                {
                    DeviceBodyModel.LatDegreePoint1 = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte LatDegreePoint2
        {
            get { return DeviceBodyModel.LatDegreePoint2; }
            set
            {
                if (DeviceBodyModel.LatDegreePoint2 != null)
                {
                    DeviceBodyModel.LatDegreePoint2 = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte LatDegreePoint3
        {
            get { return DeviceBodyModel.LatDegreePoint3; }
            set
            {
                if (DeviceBodyModel.LatDegreePoint3 != null)
                {
                    DeviceBodyModel.LatDegreePoint3 = value;
                    OnPropertyChanged();
                }
            }
        }
        public char NS
        {
            get { return DeviceBodyModel.NS; }
            set
            {
                if (DeviceBodyModel.NS != null)
                {
                    DeviceBodyModel.NS = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte LongDegree
        {
            get { return DeviceBodyModel.LongDegree; }
            set
            {
                if (DeviceBodyModel.LongDegree != null)
                {
                    DeviceBodyModel.LongDegree = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte LongDegreePoint1
        {
            get { return DeviceBodyModel.LongDegreePoint1; }
            set
            {
                if (DeviceBodyModel.LongDegreePoint1 != null)
                {
                    DeviceBodyModel.LongDegreePoint1 = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte LongDegreePoint2
        {
            get { return DeviceBodyModel.LongDegreePoint2; }
            set
            {
                if (DeviceBodyModel.LongDegreePoint2 != null)
                {
                    DeviceBodyModel.LongDegreePoint2 = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte LongDegreePoint3
        {
            get { return DeviceBodyModel.LongDegreePoint3; }
            set
            {
                if (DeviceBodyModel.LongDegreePoint3 != null)
                {
                    DeviceBodyModel.LongDegreePoint3 = value;
                    OnPropertyChanged();
                }
            }
        }
        public char EW
        {
            get { return DeviceBodyModel.EW; }
            set
            {
                if (DeviceBodyModel.EW != null)
                {
                    DeviceBodyModel.EW = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Speed
        {
            get { return DeviceBodyModel.Speed; }
            set
            {
                if (DeviceBodyModel.Speed != null)
                {
                    DeviceBodyModel.Speed = value;
                    OnPropertyChanged();
                }
            }
        }
        public string MaxSpeed
        {
            get { return DeviceBodyModel.MaxSpeed; }
            set
            {
                if (DeviceBodyModel.MaxSpeed != null)
                {
                    DeviceBodyModel.MaxSpeed = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsCharging
        {
            get { return DeviceBodyModel.IsCharging; }
            set
            {
                if (DeviceBodyModel.IsCharging != null)
                {
                    DeviceBodyModel.IsCharging = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Battery
        {
            get { return DeviceBodyModel.Battery; }
            set
            {
                if (DeviceBodyModel.Battery != null)
                {
                    DeviceBodyModel.Battery = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Temp
        {
            get { return DeviceBodyModel.Temp; }
            set
            {
                if (DeviceBodyModel.Temp != null)
                {
                    DeviceBodyModel.Temp = value;
                    OnPropertyChanged();
                }
            }
        }
        public string AcclX
        {
            get { return DeviceBodyModel.AcclX; }
            set
            {
                if (DeviceBodyModel.AcclX != null)
                {
                    DeviceBodyModel.AcclX = value;
                    OnPropertyChanged();
                }
            }
        }
        public string AcclY
        {
            get { return DeviceBodyModel.AcclY; }
            set
            {
                if (DeviceBodyModel.AcclY != null)
                {
                    DeviceBodyModel.AcclY = value;
                    OnPropertyChanged();
                }
            }
        }
        public string AcclZ
        {
            get { return DeviceBodyModel.AcclZ; }
            set
            {
                if (DeviceBodyModel.AcclZ != null)
                {
                    DeviceBodyModel.AcclZ = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Alarm
        {
            get { return DeviceBodyModel.Alarm; }
            set
            {
                if (DeviceBodyModel.Alarm != null)
                {
                    DeviceBodyModel.Alarm = value;
                    OnPropertyChanged();
                }
            }
        }
        public short GeofenceInOutIndex
        {
            get { return DeviceBodyModel.GeofenceInOutIndex; }
            set
            {
                if (DeviceBodyModel.GeofenceInOutIndex != null)
                {
                    DeviceBodyModel.GeofenceInOutIndex = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte GeofenceInOutState
        {
            get { return DeviceBodyModel.GeofenceInOutState; }
            set
            {
                if (DeviceBodyModel.GeofenceInOutState != null)
                {
                    DeviceBodyModel.GeofenceInOutState = value;
                    OnPropertyChanged();
                }
            }
        }
        public char CommCode
        {
            get { return DeviceBodyModel.CommCode; }
            set
            {
                if (DeviceBodyModel.CommCode != null)
                {
                    DeviceBodyModel.CommCode = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
