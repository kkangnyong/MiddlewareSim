using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Store;

namespace SimReeferMiddlewareSystemWPF.ViewModel.Menu
{
    public class IDGenerateServerRegistPacketViewModel : ViewModelBase
    {
        private static IDGenerateServerRegistPacketViewModel _instance;
        public IDGenerateServerRegistPacketViewModel Instance { get { if (_instance == null) _instance = new IDGenerateServerRegistPacketViewModel(); return _instance; } }

        private IDGenerateInfoStore _idGenerateInfoStore;

        private IDGenerateInfoModel _idGenerateInfoModel;
        public IDGenerateInfoModel IDGenerateInfoModel { get { if (_idGenerateInfoModel == null) _idGenerateInfoModel = Instance._idGenerateInfoStore._currentIDGenerateInfo = new IDGenerateInfoModel(); return _idGenerateInfoModel; } }

        public IDGenerateServerRegistPacketViewModel() { }

        public IDGenerateServerRegistPacketViewModel(IDGenerateInfoStore idGenerateInfoStore)
        {
            _instance = this;
            Instance._idGenerateInfoStore = idGenerateInfoStore;
        }

        public string APN
        {
            get { return IDGenerateInfoModel.APN; }
            set
            {
                if (IDGenerateInfoModel.APN != null)
                {
                    IDGenerateInfoModel.APN = value;
                    OnPropertyChanged();
                }
            }
        }
        public string DeviceType
        {
            get { return IDGenerateInfoModel.DeviceType; }
            set
            {
                if (IDGenerateInfoModel.DeviceType != null)
                {
                    IDGenerateInfoModel.DeviceType = value;
                    OnPropertyChanged();
                }
            }
        }
        public string HwVer
        {
            get { return IDGenerateInfoModel.HwVer; }
            set
            {
                if (IDGenerateInfoModel.HwVer != null)
                {
                    IDGenerateInfoModel.HwVer = value;
                    OnPropertyChanged();
                }
            }
        }
        public string SwVer
        {
            get { return IDGenerateInfoModel.SwVer; }
            set
            {
                if (IDGenerateInfoModel.SwVer != null)
                {
                    IDGenerateInfoModel.SwVer = value;
                    OnPropertyChanged();
                }
            }
        }
        public string MCU
        {
            get { return IDGenerateInfoModel.Mcu; }
            set
            {
                if (IDGenerateInfoModel.Mcu != null)
                {
                    IDGenerateInfoModel.Mcu = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Mobile
        {
            get { return IDGenerateInfoModel.Mobile; }
            set
            {
                if (IDGenerateInfoModel.Mobile != null)
                {
                    IDGenerateInfoModel.Mobile = value;
                    OnPropertyChanged();
                }
            }
        }
        public string MobileIMEI
        {
            get { return IDGenerateInfoModel.MobileIMEI; }
            set
            {
                if (IDGenerateInfoModel.MobileIMEI != null)
                {
                    IDGenerateInfoModel.MobileIMEI = value;
                    OnPropertyChanged();
                }
            }
        }
        public short Period
        {
            get { return IDGenerateInfoModel.Period; }
            set
            {
                if (IDGenerateInfoModel.Period != null)
                {
                    IDGenerateInfoModel.Period = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Usim
        {
            get { return IDGenerateInfoModel.Usim; }
            set
            {
                if (IDGenerateInfoModel.Usim != null)
                {
                    IDGenerateInfoModel.Usim = value;
                    OnPropertyChanged();
                }
            }
        }
        public short GpsTimeout
        {
            get { return IDGenerateInfoModel.GpsTimeout; }
            set
            {
                if (IDGenerateInfoModel.GpsTimeout != null)
                {
                    IDGenerateInfoModel.GpsTimeout = value;
                    OnPropertyChanged();
                }
            }
        }
        public short GpsStableTime
        {
            get { return IDGenerateInfoModel.GpsStableTime; }
            set
            {
                if (IDGenerateInfoModel.GpsStableTime != null)
                {
                    IDGenerateInfoModel.GpsStableTime = value;
                    OnPropertyChanged();
                }
            }
        }
        public short WireConnTimeout
        {
            get { return IDGenerateInfoModel.WireConnTimeout; }
            set
            {
                if (IDGenerateInfoModel.WireConnTimeout != null)
                {
                    IDGenerateInfoModel.WireConnTimeout = value;
                    OnPropertyChanged();
                }
            }
        }
        public short CommRetryCount
        {
            get { return IDGenerateInfoModel.CommRetryCount; }
            set
            {
                if (IDGenerateInfoModel.CommRetryCount != null)
                {
                    IDGenerateInfoModel.CommRetryCount = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte ShockUpper
        {
            get { return IDGenerateInfoModel.ShockUpper; }
            set
            {
                if (IDGenerateInfoModel.ShockUpper != null)
                {
                    IDGenerateInfoModel.ShockUpper = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
