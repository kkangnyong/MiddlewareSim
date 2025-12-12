using SimReeferMiddlewareSystemWPF.Command;
using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Store;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace SimReeferMiddlewareSystemWPF.ViewModel.Menu
{
    public class FOTAServerViewModel : ViewModelBase
    {
        private readonly char COMMA = ',';
        private readonly IMessageBoxService _messageBoxService;
        public readonly ITcpSocketService _tcpSocketService;
        private readonly DeviceFirmwareInfoStore _deviceFirmwareInfoStore;
        private DeviceFirmwareInfoModel CurrentDeviceFirmwareInfoModel => _deviceFirmwareInfoStore._currentDeviceFirmwareInfo;

        public ICommand ToSendRawDataPacketCommand { get; set; }

        public INotifyPropertyChanged? CurrentRawDataViewModel
        {
            get { return (ViewModelBase)App.Current.Services.GetService(typeof(FOTAServerPacketViewModel)); }
        }
        public static FOTAServerViewModel _instance { get; set; }
        public FOTAServerViewModel Instance { get { if (_instance == null) _instance = new FOTAServerViewModel(); return _instance; } }

        private string _sendMessageText { get; set; } = string.Empty;

        public FOTAServerViewModel() { }

        public FOTAServerViewModel(IMessageBoxService messageBoxService,
            ITcpSocketService tcpSocketService,
            ServerConnectionStore serverConnectionStore,
            DeviceFirmwareInfoStore deviceFirmwareInfoStore)
        {
            _instance = this;
            _messageBoxService = messageBoxService;
            _tcpSocketService = tcpSocketService;
            _deviceFirmwareInfoStore = deviceFirmwareInfoStore;
            ToSendRawDataPacketCommand = new RelayCommand<object>(ToSendRawDataPacket);
        }


        private void ToSendRawDataPacket(object _)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendJoin(COMMA, new string[] {
            "deviceandfirmwareinfo",
            CurrentDeviceFirmwareInfoModel.Result,
            CurrentDeviceFirmwareInfoModel.ReqType.ToString(),
            CurrentDeviceFirmwareInfoModel.DeviceType,
            CurrentDeviceFirmwareInfoModel.DeviceNumber.ToString(),
            CurrentDeviceFirmwareInfoModel.FwVersion,
            CurrentDeviceFirmwareInfoModel.ContainerType,
            CurrentDeviceFirmwareInfoModel.ProtocolVersion,
            CurrentDeviceFirmwareInfoModel.SequenceType,
            CurrentDeviceFirmwareInfoModel.ContainerNumber,
            CurrentDeviceFirmwareInfoModel.DownloadDate,
            CurrentDeviceFirmwareInfoModel.Extension
            });

            _tcpSocketService.SendJsonMessage(sb.ToString().Trim());
        }
    }
}
