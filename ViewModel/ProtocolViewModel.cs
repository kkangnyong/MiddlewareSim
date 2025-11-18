using SimReeferMiddlewareSystemWPF.Command;
using SimReeferMiddlewareSystemWPF.Inteface;
using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Store;
using System.ComponentModel;
using System.Windows.Input;

namespace SimReeferMiddlewareSystemWPF.ViewModel
{
    public class ProtocolViewModel : ViewModelBase
    {
        //private readonly INavigationService _navigationService;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IModelData _modelDataService;
        private readonly IDeviceInfo _modelInfo;
        private readonly SignupStore _signupStore;
        private DeviceInfoViewModel CurrentDeviceInfoModel => _signupStore.CurrentDeviceInfo;
        public ICommand ToDeviceInfoCommand { get; set; }
        //public ICommand ToSetupInfoCommand { get; set; }

        public INotifyPropertyChanged? CurrentDeviceInfoViewModel
        {
            get { return (ViewModelBase)App.Current.Services.GetService(typeof(DeviceInfoViewModel)); }
        }

        public INotifyPropertyChanged? CurrentDeviceBodyViewModel
        {
            get { return (ViewModelBase)App.Current.Services.GetService(typeof(DeviceBodyViewModel)); }
        }

        private void ToDeviceInfo(object _)
        {
            Console.WriteLine(CurrentDeviceInfoModel);
            //_signupStore.CurrentDeviceInfo = new Model.DeviceInfoModel { DeviceNumber = _modelInfo.DeviceNumber };
            //_navigationService.Navigate(Service.NaviType.DeviceBodyView);
            _messageBoxService.ShowInfo(_modelInfo.DeviceNumber.ToString(), "Save");
            _modelDataService.SetDeviceInfoValues(new List<byte[]> {
                //_modelDataService.GetStringsToByteArray(),

            });
        }

        private void CurrentDeviceInfoChanged(DeviceInfoViewModel deviceInfoModel)
        {
            Console.WriteLine(deviceInfoModel.DeviceNumber);
        }

        //private void ToSetupInfo(object _)
        //{
        //    _navigationService.Navigate(Service.NaviType.SetupInfoView);
        //}

        public ProtocolViewModel() { }

        public ProtocolViewModel(IMessageBoxService messageBoxService, IModelData modelDataService, IDeviceInfo modelInfo, SignupStore signupStore)
        {
            _signupStore = signupStore;
            _signupStore.CurrentDeviceInfoChanged += CurrentDeviceInfoChanged;
            _modelInfo = modelInfo;
            _messageBoxService = messageBoxService;
            ToDeviceInfoCommand = new RelayCommand<object>(ToDeviceInfo);
            _modelDataService = modelDataService;
            //ToSetupInfoCommand = new RelayCommand<object>(ToSetupInfo);
        }
    }
}
