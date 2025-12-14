using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Store;

namespace SimReeferMiddlewareSystemWPF.ViewModel.Menu
{
    public class IDGenerateServerRegistPacketViewModel : ViewModelBase
    {

        private string _apn = string.Empty;//"onomondo";
        private string _deviceType = string.Empty;//"CTR-S200B";
        private string _hwVer = string.Empty;//"9.9.9";
        private string _mobileIMEI = string.Empty;//"862771047956522";

        private static IDGenerateServerRegistPacketViewModel _instance;
        public IDGenerateServerRegistPacketViewModel Instance { get { if (_instance == null) _instance = new IDGenerateServerRegistPacketViewModel(); return _instance; } }

        private IDGenerateInfoRegistStore _idGenerateInfoRegistStore;

        private IDGenerateInfoModel _idGenerateInfoModel;
        public IDGenerateInfoModel IDGenerateInfoModel { get { if (_idGenerateInfoModel == null) _idGenerateInfoModel = Instance._idGenerateInfoRegistStore.CurrentIDGenerateInfo = new IDGenerateInfoModel(); return _idGenerateInfoModel; } }

        public IDGenerateServerRegistPacketViewModel() { }

        public IDGenerateServerRegistPacketViewModel(IDGenerateInfoRegistStore idGenerateInfoRegistStore)
        {
            _instance = this;
            _idGenerateInfoRegistStore = idGenerateInfoRegistStore;
            _idGenerateInfoRegistStore.CurrentIDGenerateInfoChanged += OnCurrentIDGenerateInfoChanged;
        }

        private void OnCurrentIDGenerateInfoChanged(IDGenerateInfoModel model)
        {
            APN = model.APN;
            DeviceType = model.DeviceType;
            HwVer = model.HwVer;
            MobileIMEI = model.MobileIMEI;
        }

        public string APN
        {
            get { return _apn; }
            set
            {
                if (_apn != null)
                {
                    _apn = value;
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
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
            get { return IDGenerateInfoModel.MCU; }
            set
            {
                if (IDGenerateInfoModel.MCU != null)
                {
                    IDGenerateInfoModel.MCU = value;
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
