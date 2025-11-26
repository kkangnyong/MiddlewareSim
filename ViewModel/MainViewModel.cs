using SimReeferMiddlewareSystemWPF.Command;
using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Service;
using SimReeferMiddlewareSystemWPF.Store;
using SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver8;
using SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver9;
using SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver10;
using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;
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
        private readonly INavigationService _navigationService;
        private readonly IMessageBoxService _messageBoxService;
        public readonly ITcpSocketService _tcpSocketService;
        private readonly MainNavigationStore? _mainNavigationStore;
        public ICommand ToConnectCommand { get; set; }
        public ICommand ToDisconnectCommand { get; set; }

        public static MainViewModel _instance { get; set; }
        public MainViewModel Instance { get { if (_instance == null) _instance = new MainViewModel(); return _instance; } }

        private ServerConnectionStore _serverConnectionInfoStore;

        private ServerConnectionModel _serverConnectionModel;
        public ServerConnectionModel ServerConnectionModel { get { if (_serverConnectionModel == null) _serverConnectionModel = _instance._serverConnectionInfoStore._currentServerConnectionInfo = new ServerConnectionModel(); return _serverConnectionModel; } }

        private ProtocolViewModelVer8 _protocolver8;
        public ProtocolViewModelVer8 ProtocolVer8 { get { if (_protocolver8 == null) _protocolver8 = new ProtocolViewModelVer8(); return _protocolver8.Instance; } }

        private ProtocolViewModelVer9 _protocolver9;
        public ProtocolViewModelVer9 ProtocolVer9 { get { if (_protocolver9 == null) _protocolver9 = new ProtocolViewModelVer9(); return _protocolver9.Instance; } }

        private ProtocolViewModelVer10 _protocolver10;
        public ProtocolViewModelVer10 ProtocolVer10 { get { if (_protocolver10 == null) _protocolver10 = new ProtocolViewModelVer10(); return _protocolver10; } }


        private static Version? _fileVersion = Assembly.GetExecutingAssembly().GetName().Version;
        private string _title { get; set; } = $"EyeCargo Reefer Middleware Simulator - v{_fileVersion?.Major}.{_fileVersion?.Minor}.{_fileVersion?.Build}";
        private string _imagePath { get; set; } = string.Empty;
        private string _companyImagePath { get; set; } = string.Empty;
        private bool _isEnabled { get; set; } = true;
        private List<string> _protocolVerList { get; set; } = new List<string>() { "0.8.0.0", "0.9.0.0", "0.10.0.0" };

        public MainViewModel() { }

        public MainViewModel(INavigationService navigationService,
            IMessageBoxService messageBoxService,
            ITcpSocketService tcpSocketService,
            IUIControlService uIControlService,
            MainNavigationStore mainNavigationStore,
            ServerConnectionStore serverConnectionStore)
        {
            _instance = this;
            ToCompanyImage = "/Resources/Swinnus.png";
            _serverConnectionInfoStore = serverConnectionStore;
            _messageBoxService = messageBoxService;
            _tcpSocketService = tcpSocketService;
            _mainNavigationStore = mainNavigationStore;
            Initialize();
            _navigationService = navigationService;
            _navigationService.Navigate(NaviType.ProtocolView, ProtocolVersion);
        }

        private void Initialize()
        {
            _tcpSocketService.SocketAsyncConnected += SocketAsyncConnected;
            _tcpSocketService.SocketAsyncDisconnected += SocketAsyncDisconnected;
            _tcpSocketService.SocketAsyncError += SocketAsyncError;
            _tcpSocketService.NoSynchronizationSetupInfo += NoSynchronizationSetupInfo;
            _tcpSocketService.SynchronizationSetupInfo += SynchronizationSetupInfo;
            _mainNavigationStore.CurrentViewModelChanged += CurrentViewModelChanged;
            ToConnectCommand = new RelayCommand<object>(ToConnect);
            ToDisconnectCommand = new RelayCommand<object>(ToDisconnect);
        }

        private void ToConnect(object _)
        {
            ToLoadImage = "/Resources/Spinner_3.gif";
            _tcpSocketService.Connection(ServerConnectionModel.IP, ServerConnectionModel.Port);
            IsEnabled = false;
        }

        private void ToDisconnect(object _)
        {
            _tcpSocketService.Disconnection();
            ToLoadImage = string.Empty;
            IsEnabled = true;
            ProtocolVer8.Dispose();
            ProtocolVer9.Dispose();
            ProtocolVer10.Dispose();
        }

        private void NoSynchronizationSetupInfo()
        {
        }

        private void SynchronizationSetupInfo()
        {
            ProtocolVer8.IsSetupInfoEnabled = true;
            ProtocolVer9.IsSetupInfoEnabled = true;
            ProtocolVer10.IsSetupInfoEnabled = true;
        }

        private void SocketAsyncConnected()
        {
            CurrentViewModel = null;
            _navigationService.Navigate(NaviType.ProtocolView, ProtocolVersion);
            string[] strings = ProtocolVersion.Split(new string[] { ",", ".", "\t", " " }, StringSplitOptions.RemoveEmptyEntries);
            byte[] msgBytes = new byte[strings.Length];

            //프로토콜 버전 전송 시
            if (Regex.IsMatch(ProtocolVersion, @"^[0-9]{1,2}.[0-9]{1,2}.[0-9]{1,2}.[0-9]{1,2}$"))
            {
                byte[] stringsTobytes = strings.Select(byte.Parse).ToArray();
                Array.Copy(stringsTobytes, 0, msgBytes, 0, stringsTobytes.Length);
            }

            if (!_tcpSocketService.SendMsg(msgBytes, true, false)) return;

            ToLoadImage = "/Resources/Check_Mark.png";
            if (ProtocolVersion.Equals(_protocolVerList[0]))
            {
                ProtocolVer8.Instance.IsDeviceInfoEnabled = true;
            }
            else if (ProtocolVersion.Equals(_protocolVerList[1]))
            {
                ProtocolVer9.Instance.IsDeviceInfoEnabled = true;
            }
            else if (ProtocolVersion.Equals(_protocolVerList[2]))
            {
                ProtocolVer10.Instance.IsDeviceInfoEnabled = true;
            }
        }

        private void SocketAsyncDisconnected()
        {
            ToLoadImage = string.Empty;
            IsEnabled = true;
            ProtocolVer8.Dispose();
            ProtocolVer9.Dispose();
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

        public string TitleVersion
        {
            get { return _title; }
            set
            {
                if (_title != null)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<string> ProtocolVerList 
        {
            get { return _protocolVerList; }
            set 
            {
                if (_protocolVerList != null)
                {
                    _protocolVerList = value;
                    OnPropertyChanged();
                }
            }
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
                    _navigationService.Navigate(NaviType.ProtocolView, ProtocolVersion);
                }
            }
        }
    }
}
