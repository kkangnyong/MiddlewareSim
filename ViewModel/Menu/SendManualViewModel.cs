using SimReeferMiddlewareSystemWPF.Command;
using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Store;
using System.Windows.Input;

namespace SimReeferMiddlewareSystemWPF.ViewModel.Menu
{
    public class SendManualViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessageBoxService _messageBoxService;
        public readonly ITcpSocketService _tcpSocketService;
        public readonly ITableBuilderService _tableBuilderService;
        private readonly MainNavigationStore? _mainNavigationStore;
        public static SendManualViewModel _instance { get; set; }
        public SendManualViewModel Instance { get { if (_instance == null) _instance = new SendManualViewModel(); return _instance; } }

        public ICommand ToSendHexMessageCommand { get; set; }
        public ICommand ToSendJsonMessageCommand { get; set; }
        private string _sendMessageText { get; set; } = "Please Input Send Packet Data!!!";

        public SendManualViewModel() { }

        public SendManualViewModel(INavigationService navigationService,
            IMessageBoxService messageBoxService,
            ITcpSocketService tcpSocketService,
            ITableBuilderService tableBuilderService,
            MainNavigationStore mainNavigationStore,
            ServerConnectionStore serverConnectionStore)
        {
            _instance = this;
            _messageBoxService = messageBoxService;
            _tcpSocketService = tcpSocketService;
            _tableBuilderService = tableBuilderService;
            _mainNavigationStore = mainNavigationStore;
            _navigationService = navigationService;
            ToSendHexMessageCommand = new RelayCommand<object>(ToSendHexMessage);
            ToSendJsonMessageCommand = new RelayCommand<object>(ToSendJsonMessage);
        }

        private void ToSendHexMessage(object _)
        {
            _tcpSocketService.SendHexMessage(SendMessageText);
        }

        private void ToSendJsonMessage(object _)
        {
            _tcpSocketService.SendJsonMessage(SendMessageText);
        }

        public string SendMessageText 
        { 
            get { return _sendMessageText; }
            set 
            {
                if (_sendMessageText != null)
                {
                    _sendMessageText = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
