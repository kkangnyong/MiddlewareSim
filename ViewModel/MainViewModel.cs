using Mythosia;
using SimReeferMiddlewareSystemWPF.Command;
using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Service;
using SimReeferMiddlewareSystemWPF.Store;
using SimReeferMiddlewareSystemWPF.View.Menu;
using SimReeferMiddlewareSystemWPF.ViewModel.Menu;
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

        private static readonly string OK = "OK";
        private static readonly string FAILED = "FAILED";
        private static readonly string Collapsed = "Collapsed";
        private static readonly string Visible = "Visible";
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


        private IDGenerateServerViewModel _idGenerateServer;
        public IDGenerateServerViewModel IdGenerateServer { get { if (_idGenerateServer == null) _idGenerateServer = new IDGenerateServerViewModel(); return _idGenerateServer.Instance; } }

        public static SendManual _sendManualMenu { get; set; }
        public SendManual SendManualMenu { get { if (_sendManualMenu == null) _sendManualMenu = new SendManual(); return _sendManualMenu; } }


        private static Version? _fileVersion = Assembly.GetExecutingAssembly().GetName().Version;
        private string _title { get; set; } = $"EyeCargo Reefer Middleware Simulator - v{_fileVersion?.Major}.{_fileVersion?.Minor}.{_fileVersion?.Build}";
        private string _periodImagePath { get; set; } = string.Empty;
        private string _imagePath { get; set; } = string.Empty;
        private string _companyImagePath { get; set; } = string.Empty;
        private bool _isEnabled { get; set; } = true;
        private bool _isConnectEnabled { get; set; } = true;
        private bool _isDisconnectEnabled { get; set; } = true;
        private bool _isRepeatChecked { get; set; } = false;
        private bool _isRepeatEnabled { get; set; } = false;
        private bool _isCommPeriodChecked { get; set; } = false;
        private bool _isCommPeriodEnabled { get; set; } = false;
        private string _visibleCommPeriod { get; set; } = Collapsed;
        private string _visibleRepeat { get; set; } = Collapsed;
        private string _visibleMenuOption { get; set; } = Visible;
        private string _visibleConnect { get; set; } = Visible;
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

        /// <summary>
        /// 각 종 Command 또는 이벤트들 초기화
        /// </summary>
        private void Initialize()
        {
            _tcpSocketService.SocketAsyncConnected += SocketAsyncConnected;
            _tcpSocketService.SocketAsyncDisconnected += SocketAsyncDisconnected;
            _tcpSocketService.SocketAsyncError += SocketAsyncError;
            _tcpSocketService.NoSynchronizationSetupInfo += NoSynchronizationSetupInfo;
            _tcpSocketService.SynchronizationSetupInfo += SynchronizationSetupInfo;
            _tcpSocketService.RecievedByteToString += RecievedByteToString;
            _tcpSocketService.StartCommPeriodSendTimer += StartCommPeriodSendTimer;
            _mainNavigationStore.CurrentViewModelChanged += CurrentViewModelChanged;
            ToConnectCommand = new RelayCommand<object>(ToConnect);
            ToDisconnectCommand = new RelayCommand<object>(ToDisconnect);
            ToSendManualMenuCommand = new RelayCommand<object>(ToSendManualMenu);
            ToIDGenerateMenuCommand = new RelayCommand<object>(ToIDGenerateMenu);
            ToFOTAMenuCommand = new RelayCommand<object>(ToFOTAMenu);
            ToMiddlewareMenuCommand = new RelayCommand<object>(ToMiddlewareMenu);
        }

        /// <summary>
        /// Received Message Panel의 기본 메시지
        /// </summary>
        private void InitReceivedMessage()
        {
            ReceivedMessage = "Message";
            ReceivedRawMessage = "Raw Message";
        }

        /// <summary>
        /// 다른 메뉴 페이지 선택 시 현재 연결 중이던 socket 끊고 옵션 UI 초기화 진행
        /// </summary>
        private void InitMenuChanged()
        {
            VisibleMenuOption = Collapsed;
            VisibleCommPeriod = Collapsed;
            VisibleRepeat = Collapsed;
            IsCommPeriodChecked = false;
            IsRepeatChecked = false;
            _tcpSocketService.Disconnection();
        }

        /// <summary>
        /// Socket 연결 버튼 Command, 해당 Command에서는 Received Panel 기본 메시지 변경, Socket 연결 진행 중 gif실행, Socket 연결
        /// </summary>
        /// <param name="_"></param>
        private void ToConnect(object _)
        {
            InitReceivedMessage();
            if (_timer != null && !_timer.Enabled) ToLoadImage = "/Resources/Spinner_3.gif";
            _tcpSocketService.Connection(ServerConnectionModel.IP, ServerConnectionModel.Port);
            IsEnabled = false;
            IsConnectEnabled = false;
        }

        /// <summary>
        /// Socket 연결 해제 버튼 Command, Socket 연결 해제, 각 종 컨트롤 초기화, 현재 실행 중인 주기전송 Timer 존재 시 종료
        /// </summary>
        /// <param name="_"></param>
        private void ToDisconnect(object _)
        {
            _tcpSocketService.Disconnection();
            ToLoadImage = string.Empty;
            IsEnabled = true;
            IsConnectEnabled = true;
            ProtocolVer8.Dispose();
            ProtocolVer9.Dispose();
            ProtocolVer10.Dispose();
            IdGenerateServer.Dispose();

            if (_timer != null && _timer.Enabled)
            {
                IsCommPeriodEnabled = true;
                VisibleConnect = Visible;
                ToPeriodImage = string.Empty;
                _timer.Elapsed -= _timer_Elapsed;
                _timer.Stop();
            }
        }

        /// <summary>
        /// SendManual 메뉴 선택 Command
        /// </summary>
        /// <param name="_"></param>
        private void ToSendManualMenu(object _)
        {
            InitMenuChanged();
            _navigationService.Navigate(NaviType.SendManualView);
        }

        /// <summary>
        /// IDGenerate 서버 메뉴 선택
        /// </summary>
        /// <param name="_"></param>
        private void ToIDGenerateMenu(object _)
        {
            InitMenuChanged();
            _navigationService.Navigate(NaviType.IDGenerateView);
        }

        /// <summary>
        /// FOTA 서버 메뉴 선택
        /// </summary>
        /// <param name="_"></param>
        private void ToFOTAMenu(object _)
        {
            InitMenuChanged();
            _navigationService.Navigate(NaviType.FOTAView);
        }

        /// <summary>
        /// Middleware 서버 메뉴 선택
        /// </summary>
        /// <param name="_"></param>
        private void ToMiddlewareMenu(object _)
        {
            VisibleMenuOption = Visible;
            _tcpSocketService.Disconnection();
            _navigationService.Navigate(NaviType.ProtocolView, ProtocolVersion);
        }

        /// <summary>
        /// Middleware 서버에서 장비 동기화가 필요 없을 시 동작하며 서버로 부터 응답 받은 메시지 Received Panel에 표시
        /// </summary>
        /// <param name="originData"></param>
        private void NoSynchronizationSetupInfo(byte[] originData)
        {
            InitReceivedMessage();
            ProtocolVer8.IsStartDataEnabled = true;
            ProtocolVer9.IsStartDataEnabled = true;
            ProtocolVer10.IsStartDataEnabled = true;

            ReceivedMessage = (originData.Length <= 2 && originData.Sum(x => x) == 0) ? OK : FAILED;
            ReceivedRawMessage = BitConverter.ToString(originData);
        }

        /// <summary>
        /// Middleware 서버에서 장비 동기화가 필요 시 동작하며 서버로 부터 응답 받은 메시지 Received Panel에 표시
        /// </summary>
        /// <param name="syncDataDics"></param>
        /// <param name="originData"></param>
        private void SynchronizationSetupInfo(IDictionary<string, string> syncDataDics, byte[] originData)
        {
            InitReceivedMessage();
            ProtocolVer8.IsSetupInfoEnabled = true;
            ProtocolVer9.IsSetupInfoEnabled = true;
            ProtocolVer10.IsSetupInfoEnabled = true;

            ReceivedMessage = _tableBuilderService.ToString(syncDataDics.Values.ToArray(), syncDataDics.Keys.ToArray());
            ReceivedRawMessage = BitConverter.ToString(originData);
        }

        /// <summary>
        /// 각 서버 메뉴에서 응답 받은 데이터를 Received Panel에 표시
        /// </summary>
        /// <param name="originData"></param>
        private void RecievedByteToString(byte[] originData)
        {
            InitReceivedMessage();
            ReceivedMessage = (originData.Length <= 2 && originData.Sum(x => x) == 0) ? OK : FAILED;

            if (CurrentViewModel.GetType().Name.Equals(typeof(SendManualViewModel).Name)
                || CurrentViewModel.GetType().Name.Equals(typeof(FOTAServerViewModel).Name)
                || CurrentViewModel.GetType().Name.Equals(typeof(IDGenerateServerViewModel).Name))   //추후 ID Server, FOTA Server 메뉴도 조건에 추가
            {
                byte[] result = new byte[sizeof(int)];
                Array.Copy(originData, 0, result, 0, sizeof(int));
                string decimalValue = BitConverter.ToInt32(result).ToString();

                ReceivedMessage = (originData.Length > 0 && originData[0] == 255) ? OK : decimalValue;
            }
            ReceivedRawMessage = BitConverter.ToString(originData);
        }

        /// <summary>
        /// Socket에 연결이 정상적으로 완료 된 후 동작하며, Middleware서버가 아닐 시 진행 상태 애니메이션만 갱신하고 바로 반환, Middleware서버 일 시 연결 직후 선택 된 프로토콜 버전을 바로 송신
        /// </summary>
        private void SocketAsyncConnected()
        {
            if (_timer != null && !_timer.Enabled) ToLoadImage = "/Resources/Check_Mark.png";
            if (CurrentViewModel.GetType().Name.Equals(typeof(SendManualViewModel).Name)
                || CurrentViewModel.GetType().Name.Equals(typeof(FOTAServerViewModel).Name)
                || CurrentViewModel.GetType().Name.Equals(typeof(IDGenerateServerViewModel).Name)) return;   //추후 ID Server, FOTA Server 메뉴도 조건에 추가

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

        /// <summary>
        /// 주기전송 Timer 실행 함수이며, 해당 옵션 실행은 한 주기가 끝나는 시점에 함수 발동
        /// </summary>
        private void StartCommPeriodSendTimer()
        {
            if (_tcpSocketService.IsConnceted && IsCommPeriodChecked && _timer != null && !_timer.Enabled)
            {
                IsCommPeriodEnabled = false;
                VisibleConnect = Collapsed;
                _timer.Interval = CommPeriod * (1000 * 60);
                _timer.Elapsed += _timer_Elapsed;
                _timer.Start();
                ToPeriodImage = "/Resources/SendPeriod5.gif";
                _messageBoxService.ShowInfo($"전송 주기 {CommPeriod}분이 적용되어 동작 중 입니다.", "Period Send");
            }
        }

        /// <summary>
        /// Socket 연결이 완전이 해제 된 후 발동
        /// </summary>
        private void SocketAsyncDisconnected()
        {
            ToLoadImage = string.Empty;
            IsEnabled = true;
            IsConnectEnabled = true;
            ProtocolVer8.Dispose();
            ProtocolVer9.Dispose();
            ProtocolVer10.Dispose();
            IdGenerateServer.Dispose();
        }

        /// <summary>
        /// 주기전송 Timer Elapsed 이벤트이며 각 프로토콜에 해당하는 모든 패킷을 자동으로 순차 실행
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Socket 연결 에러 발생 시 발동
        /// </summary>
        /// <param name="error"></param>
        private void SocketAsyncError(string error)
        {
            ToLoadImage = "/Resources/Cancel.png";
            ToDisconnect(null);
            _messageBoxService.ShowError($"Connect Error!! - {error}", "Server");
        }

        /// <summary>
        /// 메인 화면의 주요 Conetent Panel에 현재 선택된 ViewModel객체에 할당
        /// </summary>
        private void CurrentViewModelChanged()
        {
            CurrentViewModel = _mainNavigationStore?.CurrentViewModel;
        }

        /// <summary>
        /// Socket Connect 버튼 Visible 처리 Binding 변수
        /// </summary>
        public string VisibleConnect
        {
            get { return _visibleConnect; }

            set
            {
                if (_visibleConnect != null)
                {
                    _visibleConnect = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Middleware 서버 메뉴에서 필요한 옵션 컨트롤 Visible 처리 Binding 변수
        /// </summary>
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

        /// <summary>
        /// 전송주기 옵션 컨트롤 Visible 처리 Binding 변수
        /// </summary>
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

        /// <summary>
        /// 음영구역 데이터 전송 옵션 컨트롤 Visible 처리 Binding 변수
        /// </summary>
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

        /// <summary>
        /// 전송주기 옵션 선택 Toggle버튼 Checked 처리 Binding 변수이며 해당 변수 set시 전송주기 Timer 여부보고 종료
        /// </summary>
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
                            IsCommPeriodEnabled = true;
                            VisibleConnect = Visible;
                            ToPeriodImage = string.Empty;
                            _timer.Elapsed -= _timer_Elapsed;
                            _timer.Stop();
                        }
                    }

                    VisibleCommPeriod = !_isCommPeriodChecked ? Collapsed : Visible;
                }
            }
        }

        /// <summary>
        /// 전송주기 옵션 컨트롤 Enabled 처리 Binding 변수
        /// </summary>
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

        /// <summary>
        /// 전송주기 값 Binding 변수
        /// </summary>
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
        
        /// <summary>
        /// 음영구역 데이터 옵션 선택 Toggle버튼 Checked 처리 Binding 변수
        /// </summary>
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

        /// <summary>
        /// 음영구역 옵션 컨트롤 Enabled 처리 Binding 변수
        /// </summary>
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

        /// <summary>
        /// 전송 코드(마지막 패킷여부 결정) 종류 List ComboBox Binding 변수
        /// </summary>
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

        /// <summary>
        /// 전송 코드(마지막 패킷여부 결정) 선택 SelectItem Binding 변수
        /// </summary>
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

        /// <summary>
        /// 음영구역 데이터 횟수 값 Binding 변수
        /// </summary>
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

        /// <summary>
        /// 서버로 부터 수신 한 Received 평문 메시지 데이터 값 Binding 변수
        /// </summary>
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

        /// <summary>
        /// 서버로 부터 수신 한 Received 메시지 Raw 데이터 값 Binding 변수
        /// </summary>
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
        
        /// <summary>
        /// 메인화면 Title Binding 변수
        /// </summary>
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

        /// <summary>
        /// 프로토콜 종류 값 ComboBox Biding 변수
        /// </summary>
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

        /// <summary>
        /// Socket 연결 버튼 Enabled 처리 Binding 변수
        /// </summary>
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

        /// <summary>
        /// Socket 연결 해제 버튼 Enabled 처리 Binding 변수
        /// </summary>
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

        /// <summary>
        /// 전반적인 옵션 컨트롤 Enabled 처리 Binding 변수
        /// </summary>
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

        /// <summary>
        /// 회사 로고 이미지 경로 Binding 변수
        /// </summary>
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

        /// <summary>
        /// Socket 연결 여부 이미지 경로 Binding 변수
        /// </summary>
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

        /// <summary>
        /// 전송주기 동작 여부 이미지 경로 Binding 변수
        /// </summary>
        public string ToPeriodImage
        {
            get { return _periodImagePath; }
            set
            {
                if (_periodImagePath != null)
                {
                    _periodImagePath = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Socket 연결 IP 값 Binding 변수
        /// </summary>
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

        /// <summary>
        /// Socket 연결 Port 값 Binding 변수
        /// </summary>
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

        /// <summary>
        /// 프로토콜 버전 ComboBox SelectItem 값 Binding 변수
        /// </summary>
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
