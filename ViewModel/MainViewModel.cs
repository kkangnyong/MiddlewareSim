using Mythosia;
using SimReeferMiddlewareSystemWPF.Command;
using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Service;
using SimReeferMiddlewareSystemWPF.Store;
using SimReeferMiddlewareSystemWPF.View.Menu;
using SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver10;
using SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver8;
using SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver9;
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
        public readonly ITableBuilderService _tableBuilderService;
        private readonly MainNavigationStore? _mainNavigationStore;
        public ICommand ToConnectCommand { get; set; }
        public ICommand ToDisconnectCommand { get; set; }
        public ICommand ToSendManualMenuCommand { get; set; }
        public ICommand ToIDGenerateMenuCommand { get; set; }
        public ICommand ToFOTAMenuCommand { get; set; }
        public ICommand ToMiddlewareMenuCommand { get; set; }

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
        public ProtocolViewModelVer10 ProtocolVer10 { get { if (_protocolver10 == null) _protocolver10 = new ProtocolViewModelVer10(); return _protocolver10.Instance; } }

        public static SendManual _sendManualMenu { get; set; }
        public SendManual SendManualMenu { get { if (_sendManualMenu == null) _sendManualMenu = new SendManual(); return _sendManualMenu; } }


        private static Version? _fileVersion = Assembly.GetExecutingAssembly().GetName().Version;
        private string _title { get; set; } = $"EyeCargo Reefer Middleware Simulator - v{_fileVersion?.Major}.{_fileVersion?.Minor}.{_fileVersion?.Build}";
        private string _imagePath { get; set; } = string.Empty;
        private string _companyImagePath { get; set; } = string.Empty;
        private bool _isEnabled { get; set; } = true;
        private bool _isConnectEnabled { get; set; } = true;
        private bool _isDisconnectEnabled { get; set; } = true;
        private bool _isRepeatChecked { get; set; } = false;
        private bool _isRepeatEnabled { get; set; } = false;
        private bool _isCommPeriodChecked { get; set; } = false;
        private bool _isCommPeriodEnabled { get; set; } = false;
        private string _visibleCommPeriod { get; set; } = "Collapsed";
        private string _visibleRepeat { get; set; } = "Collapsed";
        private string _visibleMenuOption { get; set; } = "Visible";
        private List<string> _protocolVerList { get; set; } = new List<string>() { ProtocolVerType.V8.ToDescription(), ProtocolVerType.V9.ToDescription(), ProtocolVerType.V10.ToDescription() };
        private string _recievedMessage { get; set; } = "Message";
        private string _recievedRawMessage { get; set; } = "Raw Message";
        private List<short> _codeList { get; set; } = new List<short>() { (short)CodeType.CommonData, (short)CodeType.LastData };
        private short _code { get; set; } = 17;
        //private int _count { get; set; } = 0;
        private int _repeatCount { get; set; } = 1;
        private short _commPeriod { get; set; } = 1;

        private System.Timers.Timer _timer = null;

        public MainViewModel() { }

        public MainViewModel(INavigationService navigationService,
            IMessageBoxService messageBoxService,
            ITcpSocketService tcpSocketService,
            ITableBuilderService tableBuilderService,
            MainNavigationStore mainNavigationStore,
            ServerConnectionStore serverConnectionStore)
        {
            _instance = this;
            ToCompanyImage = "/Resources/Swinnus.png";
            _serverConnectionInfoStore = serverConnectionStore;
            _messageBoxService = messageBoxService;
            _tcpSocketService = tcpSocketService;
            _tableBuilderService = tableBuilderService;
            _mainNavigationStore = mainNavigationStore;
            Initialize();
            _navigationService = navigationService;
            _navigationService.Navigate(NaviType.ProtocolView, ProtocolVersion);

            _timer = new System.Timers.Timer();
        }

        private void Initialize()
        {
            _tcpSocketService.SocketAsyncConnected += SocketAsyncConnected;
            _tcpSocketService.SocketAsyncDisconnected += SocketAsyncDisconnected;
            _tcpSocketService.SocketAsyncError += SocketAsyncError;
            _tcpSocketService.NoSynchronizationSetupInfo += NoSynchronizationSetupInfo;
            _tcpSocketService.SynchronizationSetupInfo += SynchronizationSetupInfo;
            _tcpSocketService.RecievedByteToString += RecievedByteToString;
            _mainNavigationStore.CurrentViewModelChanged += CurrentViewModelChanged;
            ToConnectCommand = new RelayCommand<object>(ToConnect);
            ToDisconnectCommand = new RelayCommand<object>(ToDisconnect);
            ToSendManualMenuCommand = new RelayCommand<object>(ToSendManualMenu);
            ToIDGenerateMenuCommand = new RelayCommand<object>(ToIDGenerateMenu);
            ToFOTAMenuCommand = new RelayCommand<object>(ToFOTAMenu);
            ToMiddlewareMenuCommand = new RelayCommand<object>(ToMiddlewareMenu);
        }

        private void InitReceivedMessage()
        {
            ReceivedMessage = "Message";
            ReceivedRawMessage = "Raw Message";
        }

        private void ToConnect(object _)
        {
            InitReceivedMessage();
            ToLoadImage = "/Resources/Spinner_3.gif";
            _tcpSocketService.Connection(ServerConnectionModel.IP, ServerConnectionModel.Port);
            IsEnabled = false;
            IsConnectEnabled = false;
        }

        private void ToDisconnect(object _)
        {
            _tcpSocketService.Disconnection();
            ToLoadImage = string.Empty;
            IsEnabled = true;
            IsConnectEnabled = true;
            ProtocolVer8.Dispose();
            ProtocolVer9.Dispose();
            ProtocolVer10.Dispose();
        }

        private void ToSendManualMenu(object _)
        {
            VisibleMenuOption = "Collapsed";
            VisibleCommPeriod = "Collapsed";
            VisibleRepeat = "Collapsed";
            IsCommPeriodChecked = false;
            IsRepeatChecked = false;
            _navigationService.Navigate(NaviType.SendManualView);
        }

        private void ToIDGenerateMenu(object _)
        {
        }

        private void ToFOTAMenu(object _) 
        {
        }

        private void ToMiddlewareMenu(object _)
        {
            VisibleMenuOption = "Visible";
            _navigationService.Navigate(NaviType.ProtocolView, ProtocolVersion);
        }

        private void NoSynchronizationSetupInfo(byte[] originData)
        {
            InitReceivedMessage();
            ProtocolVer8.IsStartDataEnabled = true;
            ProtocolVer9.IsStartDataEnabled = true;
            ProtocolVer10.IsStartDataEnabled = true;

            ReceivedMessage = (originData.Length <= 2 && originData.Sum(x => x) == 0) ? "OK" : "FAILED";
            ReceivedRawMessage = BitConverter.ToString(originData);
        }

        private void SynchronizationSetupInfo(IDictionary<string, string> syncDataDics, byte[] originData)
        {
            InitReceivedMessage();
            ProtocolVer8.IsSetupInfoEnabled = true;
            ProtocolVer9.IsSetupInfoEnabled = true;
            ProtocolVer10.IsSetupInfoEnabled = true;

            ReceivedMessage = _tableBuilderService.ToString(syncDataDics.Values.ToArray(), syncDataDics.Keys.ToArray());
            ReceivedRawMessage = BitConverter.ToString(originData);
        }

        private void RecievedByteToString(byte[] originData)
        {
            InitReceivedMessage();
            ReceivedMessage = (originData.Length <= 2 && originData.Sum(x => x) == 0) ? "OK" : "FAILED";
            ReceivedRawMessage = BitConverter.ToString(originData);
        }

        private void SocketAsyncConnected()
        {
            //CurrentViewModel = null;
            //_navigationService.Navigate(NaviType.ProtocolView, ProtocolVersion);
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
            IsConnectEnabled = true;
            ProtocolVer8.Dispose();
            ProtocolVer9.Dispose();
            ProtocolVer10.Dispose();

            if (IsCommPeriodChecked && _timer != null && !_timer.Enabled)
            {
                _timer.Interval = CommPeriod * (1000 * 60);
                _timer.Elapsed += _timer_Elapsed;
                _timer.Start();
                _messageBoxService.ShowInfo($"전송 주기 {CommPeriod}분이 적용되어 동작 중 입니다.", "Period Send");
            }
        }

        private void _timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            ToConnectCommand.Execute(this);
            Thread.Sleep(1000);
            if (ProtocolVersion.Equals(ProtocolVerType.V8.ToDescription()))
            {
                ProtocolVer8.AutoStart();
            }
            else if (ProtocolVersion.Equals(ProtocolVerType.V9.ToDescription()))
            {
                ProtocolVer9.AutoStart();
            }
            else if (ProtocolVersion.Equals(ProtocolVerType.V10.ToDescription()))
            {
                ProtocolVer10.AutoStart();
            }

        }

        private void SocketAsyncError(string error)
        {
            ToLoadImage = "/Resources/Cancel.png";
            IsEnabled = true;
            IsConnectEnabled = true;
            _messageBoxService.ShowError($"Connect Error!! - {error}", "Server");
        }

        private void CurrentViewModelChanged()
        {
            CurrentViewModel = _mainNavigationStore?.CurrentViewModel;
        }

        public string VisibleMenuOption
        {
            get { return _visibleMenuOption; }

            set
            {
                if (_visibleMenuOption != null)
                {
                    _visibleMenuOption = value;
                    OnPropertyChanged();
                }
            }
        }

        public string VisibleCommPeriod
        {
            get { return _visibleCommPeriod; }

            set
            {
                if (_visibleCommPeriod != null)
                {
                    _visibleCommPeriod = value;
                    OnPropertyChanged();
                }
            }
        }

        public string VisibleRepeat
        {
            get { return _visibleRepeat; }

            set
            {
                if (_visibleRepeat != null)
                {
                    _visibleRepeat = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsCommPeriodChecked
        {
            get { return _isCommPeriodChecked; }
            set
            {
                if (_isCommPeriodChecked != null)
                {
                    _isCommPeriodChecked = value;
                    OnPropertyChanged();
                    IsCommPeriodEnabled = _isCommPeriodChecked;

                    if (!_isCommPeriodChecked)
                    {
                        if (_timer != null && _timer.Enabled)
                        {
                            _timer.Elapsed -= _timer_Elapsed;
                            _timer.Stop();
                        }
                    }

                    VisibleCommPeriod = !_isCommPeriodChecked ? "Collapsed" : "Visible";
                }
            }
        }

        public bool IsCommPeriodEnabled
        {
            get { return _isCommPeriodEnabled; }
            set
            {
                if (_isCommPeriodEnabled != null)
                {
                    _isCommPeriodEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public short CommPeriod
        {
            get { return _commPeriod; }

            set
            {
                if (_commPeriod != null)
                {
                    _commPeriod = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsRepeatChecked
        {
            get { return _isRepeatChecked; }
            set
            {
                if (_isRepeatChecked != null)
                {
                    _isRepeatChecked = value;
                    OnPropertyChanged();
                    IsRepeatEnabled = _isRepeatChecked;
                    VisibleRepeat = !_isRepeatChecked ? "Collapsed" : "Visible";
                }
            }
        }

        public bool IsRepeatEnabled
        {
            get { return _isRepeatEnabled; }
            set
            {
                if (_isRepeatEnabled != null)
                {
                    _isRepeatEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<short> CodeList
        {
            get { return _codeList; }
            set
            {
                if (_codeList != null)
                {
                    _codeList = value;
                    OnPropertyChanged();
                }
            }
        }

        public short Code
        {
            get { return _code; }
            set
            {
                if (_code != null)
                {
                    _code = value;
                    OnPropertyChanged();
                }
            }
        }

        public int RepeatCount
        {
            get { return _repeatCount; }

            set
            {
                if (_repeatCount != null)
                {
                    _repeatCount = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ReceivedMessage
        {
            get { return _recievedMessage; }
            set
            {
                if (_recievedMessage != null)
                {
                    _recievedMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ReceivedRawMessage
        {
            get { return _recievedRawMessage; }
            set
            {
                if (_recievedRawMessage != null)
                {
                    _recievedRawMessage = value;
                    OnPropertyChanged();
                }
            }
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

        public bool IsConnectEnabled
        {
            get { return _isConnectEnabled; }
            set
            {
                if (_isConnectEnabled != null)
                {
                    _isConnectEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsDisconnectEnabled
        {
            get { return _isDisconnectEnabled; }
            set
            {
                if (_isDisconnectEnabled != null)
                {
                    _isDisconnectEnabled = value;
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
