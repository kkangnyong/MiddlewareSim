using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Store;

namespace SimReeferMiddlewareSystemWPF.ViewModel.Menu
{
    public class FOTAServerPacketViewModel : ViewModelBase
    {
        private static FOTAServerPacketViewModel _instance;
        public FOTAServerPacketViewModel Instance { get { if (_instance == null) _instance = new FOTAServerPacketViewModel(); return _instance; } }

        private DeviceFirmwareInfoStore _deviceFirmwareInfoStore;

        private DeviceFirmwareInfoModel _fotaServerPacketModel;
        public DeviceFirmwareInfoModel FotaServerPacketModel { get { if (_fotaServerPacketModel == null) _fotaServerPacketModel = Instance._deviceFirmwareInfoStore._currentDeviceFirmwareInfo = new DeviceFirmwareInfoModel(); return _fotaServerPacketModel; } }

        public FOTAServerPacketViewModel() { }

        public FOTAServerPacketViewModel(DeviceFirmwareInfoStore deviceFirmwareInfoStore)
        {
            _instance = this;
            Instance._deviceFirmwareInfoStore = deviceFirmwareInfoStore;
        }

        public string Result
        {
            get { return FotaServerPacketModel.Result; }
            set
            {
                if (FotaServerPacketModel.Result != null)
                {
                    FotaServerPacketModel.Result = value;
                    OnPropertyChanged();
                }
            }
        }
        public int DeviceNumber
        {
            get { return FotaServerPacketModel.DeviceNumber; }
            set
            {
                if (FotaServerPacketModel.DeviceNumber != null)
                {
                    FotaServerPacketModel.DeviceNumber = value;
                    OnPropertyChanged();
                }
            }
        }
        public string DeviceType
        {
            get { return FotaServerPacketModel.DeviceType; }
            set
            {
                if (FotaServerPacketModel.DeviceType != null)
                {
                    FotaServerPacketModel.DeviceType = value;
                    OnPropertyChanged();
                }
            }
        }
        public string FwVersion
        {
            get { return FotaServerPacketModel.FwVersion; }
            set
            {
                if (FotaServerPacketModel.FwVersion != null)
                {
                    FotaServerPacketModel.FwVersion = value;
                    OnPropertyChanged();
                }
            }
        }
        public short ReqType
        {
            get { return FotaServerPacketModel.ReqType; }
            set
            {
                if (FotaServerPacketModel.ReqType != null)
                {
                    FotaServerPacketModel.ReqType = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ProtocolVersion
        {
            get { return FotaServerPacketModel.ProtocolVersion; }
            set
            {
                if (FotaServerPacketModel.ProtocolVersion != null)
                {
                    FotaServerPacketModel.ProtocolVersion = value;
                    OnPropertyChanged();
                }
            }
        }
        public string SequenceType
        {
            get { return FotaServerPacketModel.SequenceType; }
            set
            {
                if (FotaServerPacketModel.SequenceType != null)
                {
                    FotaServerPacketModel.SequenceType = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ContainerType
        {
            get { return FotaServerPacketModel.ContainerType; }
            set
            {
                if (FotaServerPacketModel.ContainerType != null)
                {
                    FotaServerPacketModel.ContainerType = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ContainerNumber
        {
            get { return FotaServerPacketModel.ContainerNumber; }
            set
            {
                if (FotaServerPacketModel.ContainerNumber != null)
                {
                    FotaServerPacketModel.ContainerNumber = value;
                    OnPropertyChanged();
                }
            }
        }
        public string DownloadDate
        {
            get { return FotaServerPacketModel.DownloadDate; }
            set
            {
                if (FotaServerPacketModel.DownloadDate != null)
                {
                    FotaServerPacketModel.DownloadDate = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Extension
        {
            get { return FotaServerPacketModel.Extension; }
            set
            {
                if (FotaServerPacketModel.Extension != null)
                {
                    FotaServerPacketModel.Extension = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
