using SimReeferMiddlewareSystemWPF.Command;
using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Store;
using System.ComponentModel;
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

        public ICommand ToSendRawDataPacketCommand { get; set; }

        public INotifyPropertyChanged? CurrentFOTAServerPacketViewModel
        {
            get { return (ViewModelBase)App.Current.Services.GetService(typeof(FOTAServerPacketViewModel)); }
        }

        private string _sendMessageText { get; set; } = string.Empty;

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
            ToSendRawDataPacketCommand = new RelayCommand<object>(ToSendRawDataPacket);
        }


        private void ToSendRawDataPacket(object _)
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
