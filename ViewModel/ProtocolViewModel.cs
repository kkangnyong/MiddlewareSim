using SimReeferMiddlewareSystemWPF.Command;
using SimReeferMiddlewareSystemWPF.Interface;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace SimReeferMiddlewareSystemWPF.ViewModel
{
    public class ProtocolViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ICommand ToDeviceBodyCommand { get; set; }
        public ICommand ToSetupInfoCommand { get; set; }

        private void ToDeviceBody(object _)
        {
            _navigationService.Navigate(Service.NaviType.DeviceBodyView);
        }

        private void ToSetupInfo(object _)
        {
            _navigationService.Navigate(Service.NaviType.SetupInfoView);
        }

        public ProtocolViewModel() { }

        public ProtocolViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ToDeviceBodyCommand = new RelayCommand<object>(ToDeviceBody);
            ToSetupInfoCommand = new RelayCommand<object>(ToSetupInfo);
        }

        //private void CurrentViewModelChanged()
        //{
        //    CurrentViewModel = _mainNavigationProperty.CurrentViewModel;
        //}
    }
}
