using SimReeferMiddlewareSystemWPF.Command;
using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Store;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace SimReeferMiddlewareSystemWPF.ViewModel.Menu
{
    public class IDGenerateServerViewModel : ViewModelBase
    {
        private readonly char COMMA = ',';
        private readonly string _apn = "apn";
        private readonly string _device_type = "device_type";
        private readonly string _hd_ver = "hd_ver";
        private readonly string _mobile_imei = "mobile_imei";
        private readonly string _request_type = "request_type";
        private readonly string _sw_ver = "sw_ver";
        private readonly string _mcu = "mcu";
        private readonly string _mobile = "mobile";
        private readonly string _period = "period";
        private readonly string _usim = "usim";
        private readonly string _gps_timeout = "gps_timeout";
        private readonly string _gps_stable_time = "gps_stable_time";
        private readonly string _wire_conn_timeout = "wire_conn_timeout";
        private readonly string _comm_retry_cnt = "comm_retry_cnt";
        private readonly string _shock_upper = "shock_upper";
        private readonly IMessageBoxService _messageBoxService;
        public readonly ITcpSocketService _tcpSocketService;
        private readonly IDGenerateInfoStore _idGenerateInfoStore;


        private IDGenerateInfoCreateStore _idGenerateInfoCreateStore;
        private IDGenerateInfoModel CurrentIDGenerateInfoCreateModel => Instance._idGenerateInfoCreateStore._currentIDGenerateInfo;

        private static IDGenerateServerRegistPacketViewModel _createPacketViewModel;
        public IDGenerateServerRegistPacketViewModel CreatePacketViewModel { get { if (_createPacketViewModel == null) _createPacketViewModel = new IDGenerateServerRegistPacketViewModel(); return _createPacketViewModel.Instance; } }

        public ICommand ToSendIDCreatePacketCommand { get; set; }
        public ICommand ToSendIDRegistPacketCommand { get; set; }

        public INotifyPropertyChanged? CurrentIDGenerateServerCreatePacketViewModel
        {
            get { return (ViewModelBase)App.Current.Services.GetService(typeof(IDGenerateServerCreatePacketViewModel)); }
        }

        public INotifyPropertyChanged? CurrentIDGenerateServerRegistPacketViewModel
        {
            get { return (ViewModelBase)App.Current.Services.GetService(typeof(IDGenerateServerRegistPacketViewModel)); }
        }

        public static IDGenerateServerViewModel _instance { get; set; }
        public IDGenerateServerViewModel Instance { get { if (_instance == null) _instance = new IDGenerateServerViewModel(); return _instance; } }

        private bool _isIDCreateEnabled { get; set; } = true;
        private bool _isIDRegistEnabled { get; set; } = false;

        public IDGenerateServerViewModel() { }

        public IDGenerateServerViewModel(IMessageBoxService messageBoxService,
            ITcpSocketService tcpSocketService,
            ServerConnectionStore serverConnectionStore,
            IDGenerateInfoStore idGenerateInfoStore,
            IDGenerateInfoCreateStore idGenerateInfoCreateStore)
        {
            _instance = this;
            _messageBoxService = messageBoxService;
            _tcpSocketService = tcpSocketService;
            _idGenerateInfoStore = idGenerateInfoStore;
            Instance._idGenerateInfoCreateStore = idGenerateInfoCreateStore;
            ToSendIDCreatePacketCommand = new RelayCommand<object>(ToSendIDCreatePacket);
            ToSendIDRegistPacketCommand = new RelayCommand<object>(ToSendIDRegistPacket);
        }


        private void ToSendIDCreatePacket(object _)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendJoin(COMMA, new string[] {
            "{" + $"\"{_apn}\": \"{CurrentIDGenerateInfoCreateModel.APN}\"",
            $" \"{_device_type}\": \"{CurrentIDGenerateInfoCreateModel.DeviceType}\"",
            $" \"{_hd_ver}\": \"{CurrentIDGenerateInfoCreateModel.HwVer}\"",
            $" \"{_mobile_imei}\": \"{CurrentIDGenerateInfoCreateModel.MobileIMEI}\"",
            $" \"{_request_type}\": {CurrentIDGenerateInfoCreateModel.RequestType}" + "}"
            });

            string sendMsg = BitConverter.ToString(Encoding.UTF8.GetBytes(sb.ToString().Trim())).Replace('-', ' ');
            sendMsg = sendMsg.PadRight(sendMsg.Length + 1) + string.Format("{0:X2}", 0x1A);

            _tcpSocketService.SendHexMessage(sendMsg);
            IsIDCreateEnabled = false;
            IsIDRegistEnabled = true;

            CreatePacketViewModel.APN = CurrentIDGenerateInfoCreateModel.APN;
            CreatePacketViewModel.DeviceType = CurrentIDGenerateInfoCreateModel.DeviceType;
            CreatePacketViewModel.HwVer = CurrentIDGenerateInfoCreateModel.HwVer;
            CreatePacketViewModel.MobileIMEI = CurrentIDGenerateInfoCreateModel.MobileIMEI;
            //CreatePacketViewModel.IDGenerateInfoModel = new IDGenerateInfoModel()
            //{
            //    APN = CurrentIDGenerateInfoCreateModel.APN,
            //    DeviceType = CurrentIDGenerateInfoCreateModel.DeviceType,
            //    HwVer = CurrentIDGenerateInfoCreateModel.HwVer,
            //    SwVer = CurrentIDGenerateInfoCreateModel.SwVer,
            //    MCU = CurrentIDGenerateInfoCreateModel.MCU,
            //    Mobile = CurrentIDGenerateInfoCreateModel.Mobile,
            //    MobileIMEI = CurrentIDGenerateInfoCreateModel.MobileIMEI,
            //    Period = CurrentIDGenerateInfoCreateModel.Period,
            //    Usim = CurrentIDGenerateInfoCreateModel.Usim,
            //    GpsTimeout = CurrentIDGenerateInfoCreateModel.GpsTimeout,
            //    GpsStableTime = CurrentIDGenerateInfoCreateModel.GpsStableTime,
            //    WireConnTimeout = CurrentIDGenerateInfoCreateModel.WireConnTimeout,
            //    CommRetryCount = CurrentIDGenerateInfoCreateModel.CommRetryCount,
            //    ShockUpper = CurrentIDGenerateInfoCreateModel.ShockUpper
            //};
        }

        private void ToSendIDRegistPacket(object _)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendJoin(COMMA, new string[] {
            "{" + $"\"{_apn}\": \"{CreatePacketViewModel.APN}\"",
            $" \"{_device_type}\": \"{CreatePacketViewModel.DeviceType}\"",
            $" \"{_hd_ver}\": \"{CreatePacketViewModel.HwVer}\"",
            $" \"{_sw_ver}\": \"{CreatePacketViewModel.SwVer}\"",
            $" \"{_mcu}\": \"{CreatePacketViewModel.MCU}\"",
            $" \"{_mobile}\": \"{CreatePacketViewModel.Mobile}\"",
            $" \"{_mobile_imei}\": \"{CreatePacketViewModel.MobileIMEI}\"",
            $" \"{_period}\": {CreatePacketViewModel.Period}",
            $" \"{_usim}\": \"{CreatePacketViewModel.Usim}\"",
            $" \"{_gps_timeout}\": {CreatePacketViewModel.GpsTimeout}",
            $" \"{_gps_stable_time}\": {CreatePacketViewModel.GpsStableTime}",
            $" \"{_wire_conn_timeout}\": {CreatePacketViewModel.WireConnTimeout}",
            $" \"{_comm_retry_cnt}\": {CreatePacketViewModel.CommRetryCount}",
            $" \"{_shock_upper}\": {CreatePacketViewModel.ShockUpper}" + "}"
            });

            string sendMsg = BitConverter.ToString(Encoding.UTF8.GetBytes(sb.ToString().Trim())).Replace('-', ' ');
            sendMsg = sendMsg.PadRight(sendMsg.Length + 1) + string.Format("{0:X2}", 0x1A);

            _tcpSocketService.SendHexMessage(sendMsg);
            IsIDRegistEnabled = false;
            IsIDCreateEnabled = true;
        }

        public bool IsIDCreateEnabled
        {
            get { return _isIDCreateEnabled; }
            set
            {
                if (_isIDCreateEnabled != null)
                {
                    _isIDCreateEnabled = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsIDRegistEnabled
        {
            get { return _isIDRegistEnabled; }
            set
            {
                if (_isIDRegistEnabled != null)
                {
                    _isIDRegistEnabled = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
