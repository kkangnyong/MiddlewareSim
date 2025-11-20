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
        private readonly MainNavigationStore? _mainNavigationStore;
        public ICommand ToConnectCommand { get; set; }
        public ICommand ToDisconnectCommand { get; set; }

        public static MainViewModel Instance { get; set; }

        private ServerConnectionStore _serverConnectionInfoStore;

        private ServerConnectionModel _serverConnectionModel;
        public ServerConnectionModel ServerConnectionModel { get { if (_serverConnectionModel == null) _serverConnectionModel = Instance._serverConnectionInfoStore._currentServerConnectionInfo = new ServerConnectionModel(); return _serverConnectionModel; } }

        private void ToConnect(object _)
        {
            _tcpSocketService.Connection(ServerConnectionModel.IP, ServerConnectionModel.Port);
            _messageBoxService.ShowInfo("Connect!!", "Server");
        }

        private void ToDisconnect(object _)
        {
            _tcpSocketService.Disconnection();
            _messageBoxService.ShowInfo("Disconnect!!", "Server");
        }

        public MainViewModel(INavigationService navigationService, IMessageBoxService messageBoxService, ITcpSocketService tcpSocketService, 
            MainNavigationStore mainNavigationStore, 
            ServerConnectionStore serverConnectionStore)
        {
            Instance = this;
            Instance._serverConnectionInfoStore = serverConnectionStore;
            _messageBoxService = messageBoxService;
            _tcpSocketService = tcpSocketService;
            _mainNavigationStore = mainNavigationStore;
            _mainNavigationStore.CurrentViewModelChanged += CurrentViewModelChanged;
            navigationService.Navigate(NaviType.ProtocolView);
            ToConnectCommand = new RelayCommand<object>(ToConnect);
            ToDisconnectCommand = new RelayCommand<object>(ToDisconnect);
        }

        private void CurrentViewModelChanged()
        {
            CurrentViewModel = _mainNavigationStore?.CurrentViewModel;
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
