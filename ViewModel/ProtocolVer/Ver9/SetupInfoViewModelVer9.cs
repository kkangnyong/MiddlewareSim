using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Store;

namespace SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver9
{
    public class SetupInfoViewModelVer9 : ViewModelBase
    {
        private static SetupInfoViewModelVer9 _instance;
        public SetupInfoViewModelVer9 Instance { get { if (_instance == null) _instance = new SetupInfoViewModelVer9(); return _instance; } }

        private SetupInfoStore _setupInfoStore;

        private SetupInfoModel _setupInfoModel;
        public SetupInfoModel SetupInfoModel { get { if (_setupInfoModel == null) _setupInfoModel = Instance._setupInfoStore._currentSetupInfo = new SetupInfoModel(); return _setupInfoModel; } }

        public SetupInfoViewModelVer9() { }

        public SetupInfoViewModelVer9(SetupInfoStore setupInfoStore)
        {
            _instance = this;
            _setupInfoStore = setupInfoStore;
        }

        public int Code
        {
            get { return SetupInfoModel.Code; }
            set
            {
                if (SetupInfoModel.Code != null)
                {
                    SetupInfoModel.Code = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte CCPR
        {
            get { return SetupInfoModel.CCPR; }
            set
            {
                if (SetupInfoModel.CCPR != null)
                {
                    SetupInfoModel.CCPR = value;
                    OnPropertyChanged();
                }
            }
        }
        public ushort CommPeriod
        {
            get { return SetupInfoModel.CommPeriod; }
            set
            {
                if (SetupInfoModel.CommPeriod != null)
                {
                    SetupInfoModel.CommPeriod = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte GpsTimeout
        {
            get { return SetupInfoModel.GpsTimeout; }
            set
            {
                if (SetupInfoModel.GpsTimeout != null)
                {
                    SetupInfoModel.GpsTimeout = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte GpsStableTime
        {
            get { return SetupInfoModel.GpsStableTime; }
            set
            {
                if (SetupInfoModel.GpsStableTime != null)
                {
                    SetupInfoModel.GpsStableTime = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte WireConnTimeOut
        {
            get { return SetupInfoModel.WireConnTimeOut; }
            set
            {
                if (SetupInfoModel.WireConnTimeOut != null)
                {
                    SetupInfoModel.WireConnTimeOut = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte RetryCount
        {
            get { return SetupInfoModel.RetryCount; }
            set
            {
                if (SetupInfoModel.RetryCount != null)
                {
                    SetupInfoModel.RetryCount = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte RcCount
        {
            get { return SetupInfoModel.RcCount; }
            set
            {
                if (SetupInfoModel.RcCount != null)
                {
                    SetupInfoModel.RcCount = value;
                    OnPropertyChanged();
                }
            }
        }
        public ushort TotalStandbyCount
        {
            get { return SetupInfoModel.TotalStandbyCount; }
            set
            {
                if (SetupInfoModel.TotalStandbyCount != null)
                {
                    SetupInfoModel.TotalStandbyCount = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte AccelShockUpper
        {
            get { return SetupInfoModel.AccelShockUpper; }
            set
            {
                if (SetupInfoModel.AccelShockUpper != null)
                {
                    SetupInfoModel.AccelShockUpper = value;
                    OnPropertyChanged();
                }
            }
        }
        public short SetTempLower
        {
            get { return SetupInfoModel.SetTempLower; }
            set
            {
                if (SetupInfoModel.SetTempLower != null)
                {
                    SetupInfoModel.SetTempLower = value;
                    OnPropertyChanged();
                }
            }
        }
        public short SetTempUpper
        {
            get { return SetupInfoModel.SetTempUpper; }
            set
            {
                if (SetupInfoModel.SetTempUpper != null)
                {
                    SetupInfoModel.SetTempUpper = value;
                    OnPropertyChanged();
                }
            }
        }
        public short HumidLower
        {
            get { return SetupInfoModel.HumidLower; }
            set
            {
                if (SetupInfoModel.HumidLower != null)
                {
                    SetupInfoModel.HumidLower = value;
                    OnPropertyChanged();
                }
            }
        }
        public ushort HumidUpper
        {
            get { return SetupInfoModel.HumidUpper; }
            set
            {
                if (SetupInfoModel.HumidUpper != null)
                {
                    SetupInfoModel.HumidUpper = value;
                    OnPropertyChanged();
                }
            }
        }
        public ushort StateChangeAlarm
        {
            get { return SetupInfoModel.StateChangeAlarm; }
            set
            {
                if (SetupInfoModel.StateChangeAlarm != null)
                {
                    SetupInfoModel.StateChangeAlarm = value;
                    OnPropertyChanged();
                }
            }
        }
        public string CutOffVoltage
        {
            get { return SetupInfoModel.CutOffVoltage; }
            set
            {
                if (SetupInfoModel.CutOffVoltage != null)
                {
                    SetupInfoModel.CutOffVoltage = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
