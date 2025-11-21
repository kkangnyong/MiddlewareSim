using SimReeferMiddlewareSystemWPF.Command;
using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Service;
using SimReeferMiddlewareSystemWPF.Store;
using SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver8;
using System.ComponentModel;
using System.Windows.Input;

namespace SimReeferMiddlewareSystemWPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private INotifyPropertyChanged? _currentViewModel;

        public INotifyPropertyChanged? CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;
                    OnPropertyChanged();
                }
            }
        }
        private readonly IMessageBoxService _messageBoxService;
        private readonly ITcpSocketService _tcpSocketService;
        private readonly IUIControlService _uiControlService;
        private readonly MainNavigationStore? _mainNavigationStore;
        public ICommand ToConnectCommand { get; set; }
        public ICommand ToDisconnectCommand { get; set; }

        public static MainViewModel Instance { get; set; }

        private ServerConnectionStore _serverConnectionInfoStore;

        private ServerConnectionModel _serverConnectionModel;
        public ServerConnectionModel ServerConnectionModel { get { if (_serverConnectionModel == null) _serverConnectionModel = Instance._serverConnectionInfoStore._currentServerConnectionInfo = new ServerConnectionModel(); return _serverConnectionModel; } }

        private ProtocolViewModelVer8 _protocolver8;
        public ProtocolViewModelVer8 ProtocolVer8 { get { if (_protocolver8 == null) _protocolver8 = new ProtocolViewModelVer8(); return _protocolver8; } }

        private string _imagePath { get; set; } = string.Empty;
        private string _companyImagePath { get; set; } = string.Empty;
        private bool _isEnabled { get; set; } = true;

        public MainViewModel(INavigationService navigationService,
            IMessageBoxService messageBoxService,
            ITcpSocketService tcpSocketService,
            IUIControlService uIControlService,
            MainNavigationStore mainNavigationStore,
            ServerConnectionStore serverConnectionStore)
        {
            Instance = this;
            ToCompanyImage = "/Resources/Swinnus.png";
            _serverConnectionInfoStore = serverConnectionStore;
            _messageBoxService = messageBoxService;
            _tcpSocketService = tcpSocketService;
            _uiControlService = uIControlService;
            _mainNavigationStore = mainNavigationStore;
            Initialize();
            navigationService.Navigate(NaviType.ProtocolView);
        }

        private void Initialize()
        {
            _tcpSocketService.SocketAsyncConnected += SocketAsyncConnected;
            _tcpSocketService.SocketAsyncDisconnected += SocketAsyncDisconnected;
            _tcpSocketService.SocketAsyncError += SocketAsyncError;
            _mainNavigationStore.CurrentViewModelChanged += CurrentViewModelChanged;
            ToConnectCommand = new RelayCommand<object>(ToConnect);
            ToDisconnectCommand = new RelayCommand<object>(ToDisconnect);
        }

        private void ToConnect(object _)
        {
            ToLoadImage = "/Resources/Spinner_3.gif";
            _tcpSocketService.Connection(ServerConnectionModel.IP, ServerConnectionModel.Port);
        }

        private void ToDisconnect(object _)
        {
            ToLoadImage = string.Empty;
            _tcpSocketService.Disconnection();
        }

        private void SocketAsyncConnected()
        {
            ToLoadImage = "/Resources/Check_Mark.png";
            IsEnabled = false;
            ProtocolVer8.Instance.IsDeviceInfoEnabled = true;
        }

        private void SocketAsyncDisconnected()
        {
            ToLoadImage = string.Empty;
            IsEnabled = true;
            ProtocolVer8.Instance.IsDeviceInfoEnabled = false;
            ProtocolVer8.Instance.IsSetupInfoEnabled = false;
            ProtocolVer8.Instance.IsStartDataEnabled = false;
            ProtocolVer8.Instance.IsDeviceDataEnabled = false;
            ProtocolVer8.Instance.IsReeferDataEnabled = false;
            ProtocolVer8.Instance.IsStartCommandEnabled = false;
        }

        private void SocketAsyncError(string error)
        {
            ToLoadImage = "/Resources/Cancel.png";
            IsEnabled = true;
            _messageBoxService.ShowError($"Connect Error!! - {error}", "Server");
        }

        private void CurrentViewModelChanged()
        {
            CurrentViewModel = _mainNavigationStore?.CurrentViewModel;
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (_isEnabled != null)
                {
                    _isEnabled = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public string ToCompanyImage
        {
            get { return _companyImagePath; }
            set
            {
                if (_companyImagePath != null)
                {
                    _companyImagePath = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ToLoadImage
        {
            get  { return _imagePath; }
            set
            {
                if (_imagePath != null)
                {
                    _imagePath = value;
                    OnPropertyChanged();
                }
            }
        }

        public string IP
        {
            get { return ServerConnectionModel.IP; }
            set
            {
                if (ServerConnectionModel.IP != null)
                {
                    ServerConnectionModel.IP = value;
                    OnPropertyChanged();
                }
            }
        }

        public ushort Port
        {
            get { return ServerConnectionModel.Port; }
            set
            {
                if (ServerConnectionModel.Port != null)
                {
                    ServerConnectionModel.Port = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ProtocolVersion
        {
            get { return ServerConnectionModel.ProtocolVersion; }
            set
            {
                if (ServerConnectionModel.ProtocolVersion != null)
                {
                    ServerConnectionModel.ProtocolVersion = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
