using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Store;

namespace SimReeferMiddlewareSystemWPF.ViewModel.Menu
{
    public class IDGenerateServerCreatePacketViewModel : ViewModelBase
    {
        private static IDGenerateServerCreatePacketViewModel _instance;
        public IDGenerateServerCreatePacketViewModel Instance { get { if (_instance == null) _instance = new IDGenerateServerCreatePacketViewModel(); return _instance; } }

        private IDGenerateInfoCreateStore _idGenerateInfoCreateStore;

        private IDGenerateInfoModel _idGenerateInfoModel;
        public IDGenerateInfoModel IDGenerateInfoModel { get { if (_idGenerateInfoModel == null) _idGenerateInfoModel = Instance._idGenerateInfoCreateStore._currentIDGenerateInfo = new IDGenerateInfoModel(); return _idGenerateInfoModel; } }

        public IDGenerateServerCreatePacketViewModel() { }

        public IDGenerateServerCreatePacketViewModel(IDGenerateInfoCreateStore idGenerateInfoCreateStore)
        {
            _instance = this;
            _idGenerateInfoCreateStore = idGenerateInfoCreateStore;
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
        public byte ReqType
        {
            get { return IDGenerateInfoModel.RequestType; }
            set
            {
                if (IDGenerateInfoModel.RequestType != null)
                {
                    IDGenerateInfoModel.RequestType = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
