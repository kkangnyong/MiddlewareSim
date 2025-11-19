using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Store;
using SimReeferMiddlewareSystemWPF.ViewModel;
using SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver8;
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

        public void Navigate(NaviType type)
        {
            switch (type)
            {
                case NaviType.DeviceBodyView:
                    CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(DeviceBodyViewModelVer8));
                    break;
                case NaviType.DeviceInfoView:
                    CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(DeviceInfoViewModelVer8));
                    break;
                case NaviType.ReeferBodyView:
                    CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(ReeferBodyViewModelVer8));
                    break;
                case NaviType.SetupInfoView:
                    CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(SetupInfoViewModelVer8));
                    break;
                default:
                    CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(ProtocolViewModelVer8));
                    break;
            }
        }
    }
}
