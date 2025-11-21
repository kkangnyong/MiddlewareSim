using SimReeferMiddlewareSystemWPF.Command;
using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Service;
using SimReeferMiddlewareSystemWPF.Store;
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

        private string _imagePath { get; set; } = string.Empty;
        private bool _isEnabled { get; set; } = true;

        public MainViewModel(INavigationService navigationService,
            IMessageBoxService messageBoxService,
            ITcpSocketService tcpSocketService,
            IUIControlService uIControlService,
            MainNavigationStore mainNavigationStore,
            ServerConnectionStore serverConnectionStore)
        {
            Instance = this;
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
        }

        private void SocketAsyncDisconnected()
        {
            ToLoadImage = string.Empty;
            IsEnabled = true;
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
