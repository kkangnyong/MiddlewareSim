using SimReeferMiddlewareSystemWPF.Command;
using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Store;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace SimReeferMiddlewareSystemWPF.ViewModel.Menu
{
    public class FOTAServerViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMessageBoxService _messageBoxService;
        public readonly ITcpSocketService _tcpSocketService;
        public readonly ITableBuilderService _tableBuilderService;
        private readonly MainNavigationStore? _mainNavigationStore;
        public static FOTAServerViewModel _instance { get; set; }
        public FOTAServerViewModel Instance { get { if (_instance == null) _instance = new FOTAServerViewModel(); return _instance; } }

        public ICommand ToSendHexMessageCommand { get; set; }
        public ICommand ToSendJsonMessageCommand { get; set; }
        public ICommand ToRichTextChangedCommand { get; set; }

        private static readonly string _welcomeMessage = "Please Input Send Packet Data!!!";
        private string _sendMessageText { get; set; } = _welcomeMessage;

        public FOTAServerViewModel() { }

        public FOTAServerViewModel(INavigationService navigationService,
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
            ToRichTextChangedCommand = new RelayCommand<object>(ToRichTextChanged);
        }

        private void ToRichTextChanged(object parameter)
        {
            string text = string.Empty;
            if (parameter is RichTextBox rtb)
            {
                text = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd).Text.TrimEnd();

                if (!string.IsNullOrEmpty(text) && text.Contains(_welcomeMessage))
                {
                    rtb.Document.Blocks.Clear();
                }
            }
            SendMessageText = text;
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
