using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Store;
using SimReeferMiddlewareSystemWPF.ViewModel;
using SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver8;
using SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver9;
using System.ComponentModel;

namespace SimReeferMiddlewareSystemWPF.Service
{
    public class NavigationService : INavigationService
    {
        private readonly MainNavigationStore _mainNavigationProperty;
        private INotifyPropertyChanged CurrentViewModel { set => _mainNavigationProperty.CurrentViewModel = value; }
        public NavigationService(MainNavigationStore mainNavi)
        {
            _mainNavigationProperty = mainNavi;
        }
        private List<string> _protocolVerList { get; set; } = new List<string>() { "0.8.0.0", "0.9.0.0", "0.10.0.0" };

        public void Navigate(NaviType type, string protocolVer)
        {
            switch (type)
            {
                case NaviType.DeviceBodyView:
                    if (protocolVer.Equals(_protocolVerList[0]))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(DeviceBodyViewModelVer8));
                    }
                    else if (protocolVer.Equals(_protocolVerList[1]))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(DeviceBodyViewModelVer9));
                    }
                    else if (protocolVer.Equals(_protocolVerList[2]))
                    {
                    }
                    break;
                case NaviType.DeviceInfoView:
                    if (protocolVer.Equals(_protocolVerList[0]))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(DeviceInfoViewModelVer8));
                    }
                    else if (protocolVer.Equals(_protocolVerList[1]))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(DeviceInfoViewModelVer9));
                    }
                    else if (protocolVer.Equals(_protocolVerList[2]))
                    {
                    }
                    break;
                case NaviType.ReeferBodyView:
                    if (protocolVer.Equals(_protocolVerList[0]))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(ReeferBodyViewModelVer8));
                    }
                    else if (protocolVer.Equals(_protocolVerList[1]))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(ReeferBodyViewModelVer9));
                    }
                    else if (protocolVer.Equals(_protocolVerList[2]))
                    {
                    }
                    break;
                case NaviType.SetupInfoView:
                    if (protocolVer.Equals(_protocolVerList[0]))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(SetupInfoViewModelVer8));
                    }
                    else if (protocolVer.Equals(_protocolVerList[1]))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(SetupInfoViewModelVer9));
                    }
                    else if (protocolVer.Equals(_protocolVerList[2]))
                    {
                    }
                    break;
                case NaviType.SensorBodyView:
                    if (protocolVer.Equals(_protocolVerList[1]))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(SensorBodyViewModelVer9));
                    }
                    else if (protocolVer.Equals(_protocolVerList[2]))
                    {
                    }
                    break;
                default:
                    if (protocolVer.Equals(_protocolVerList[0]))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(ProtocolViewModelVer8));
                    }
                    else if (protocolVer.Equals(_protocolVerList[1]))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(ProtocolViewModelVer9));
                    }
                    else if (protocolVer.Equals(_protocolVerList[2]))
                    {
                    }
                    break;
            }
        }
    }
}
