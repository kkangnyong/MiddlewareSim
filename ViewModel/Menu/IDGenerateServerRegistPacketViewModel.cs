using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Store;

namespace SimReeferMiddlewareSystemWPF.ViewModel.Menu
{
    public class IDGenerateServerRegistPacketViewModel : ViewModelBase
    {
        private string _apn = "onomondo";
        private string _deviceType = "CTR-S200B";
        private string _hwVer = "9.9.9";
        private string _mobileIMEI = "862771047956522";
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

        private static IDGenerateServerRegistPacketViewModel _instance;
        public IDGenerateServerRegistPacketViewModel Instance { get { if (_instance == null) _instance = new IDGenerateServerRegistPacketViewModel(); return _instance; } }

        private static IDGenerateServerCreatePacketViewModel _createPacketViewModel;
        public IDGenerateServerCreatePacketViewModel CreatePacketViewModel { get { if (_createPacketViewModel == null) _createPacketViewModel = new IDGenerateServerCreatePacketViewModel(); return _createPacketViewModel.Instance; } }

        private IDGenerateInfoRegistStore _idGenerateInfoRegistStore;

        private IDGenerateInfoModel _idGenerateInfoModel;
        public IDGenerateInfoModel IDGenerateInfoModel { get { return _instance._idGenerateInfoModel = new IDGenerateInfoModel(); } set { if (_instance._idGenerateInfoModel != null) _instance._idGenerateInfoModel = value; } }

        public IDGenerateServerRegistPacketViewModel() { }

        public IDGenerateServerRegistPacketViewModel(IDGenerateInfoRegistStore idGenerateInfoRegistStore)
        {
            _instance = this;
            _instance._idGenerateInfoRegistStore = idGenerateInfoRegistStore;
            _instance._idGenerateInfoRegistStore.CurrentIDGenerateInfoChanged += OnCurrentIDGenerateInfoChanged;
        }

        private void OnCurrentIDGenerateInfoChanged(IDGenerateInfoModel model)
        {
            Instance.APN = model.APN;
            Instance.DeviceType = model.DeviceType;
            Instance.HwVer = model.HwVer;
            Instance.MobileIMEI = model.MobileIMEI;
            Instance.SwVer = model.SwVer;
            Instance.MCU = model.MCU;
            Instance.Mobile = model.Mobile;
            Instance.Period = model.Period;
            Instance.Usim = model.Usim;
            Instance.GpsTimeout = model.GpsTimeout;
            Instance.GpsStableTime = model.GpsStableTime;
            Instance.WireConnTimeout = model.WireConnTimeout;
            Instance.CommRetryCount = model.CommRetryCount;
            Instance.ShockUpper = model.ShockUpper;
        }

        public string APN
        {
            get { return Instance._apn; }
            set
            {
                if (Instance._apn != null)
                {
                    Instance._apn = value;
                    OnPropertyChanged();
                }
            }
        }
        public string DeviceType
        {
            get { return Instance._deviceType; }
            set
            {
                if (Instance._deviceType != null)
                {
                    Instance._deviceType = value;
                    OnPropertyChanged();
                }
            }
        }
        public string HwVer
        {
            get { return Instance._hwVer; }
            set
            {
                if (Instance._hwVer != null)
                {
                    Instance._hwVer = value;
                    OnPropertyChanged();
                }
            }
        }
        public string SwVer
        {
            get { return Instance._swVer; }
            set
            {
                if (Instance._swVer != null)
                {
                    Instance._swVer = value;
                    OnPropertyChanged();
                }
            }
        }
        public string MCU
        {
            get { return Instance._mcu; }
            set
            {
                if (Instance._mcu != null)
                {
                    Instance._mcu = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Mobile
        {
            get { return Instance._mobile; }
            set
            {
                if (Instance._mobile != null)
                {
                    Instance._mobile = value;
                    OnPropertyChanged();
                }
            }
        }
        public string MobileIMEI
        {
            get { return Instance._mobileIMEI; }
            set
            {
                if (Instance._mobileIMEI != null)
                {
                    Instance._mobileIMEI = value;
                    OnPropertyChanged();
                }
            }
        }
        public short Period
        {
            get { return Instance._period; }
            set
            {
                if (Instance._period != null)
                {
                    Instance._period = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Usim
        {
            get { return Instance._usim; }
            set
            {
                if (Instance._usim != null)
                {
                    Instance._usim = value;
                    OnPropertyChanged();
                }
            }
        }
        public short GpsTimeout
        {
            get { return Instance._gpsTimeout; }
            set
            {
                if (Instance._gpsTimeout != null)
                {
                    Instance._gpsTimeout = value;
                    OnPropertyChanged();
                }
            }
        }
        public short GpsStableTime
        {
            get { return Instance._gpsStableTime; }
            set
            {
                if (Instance._gpsStableTime != null)
                {
                    Instance._gpsStableTime = value;
                    OnPropertyChanged();
                }
            }
        }
        public short WireConnTimeout
        {
            get { return Instance._wireConnTimeout; }
            set
            {
                if (Instance._wireConnTimeout != null)
                {
                    Instance._wireConnTimeout = value;
                    OnPropertyChanged();
                }
            }
        }
        public short CommRetryCount
        {
            get { return Instance._commRetryCount; }
            set
            {
                if (Instance._commRetryCount != null)
                {
                    Instance._commRetryCount = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte ShockUpper
        {
            get { return Instance._shockUpper; }
            set
            {
                if (Instance._shockUpper != null)
                {
                    Instance._shockUpper = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
