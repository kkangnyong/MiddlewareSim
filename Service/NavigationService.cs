using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Store;
using SimReeferMiddlewareSystemWPF.ViewModel;
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
                    CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(DeviceBodyViewModel));
                    break;
                case NaviType.DeviceInfoView:
                    CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(DeviceInfoViewModel));
                    break;
                case NaviType.ReeferBodyView:
                    break;
                case NaviType.SetupInfoView:
                    CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(SetupInfoModel));
                    break;
                default:
                    CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(ProtocolViewModel));
                    break;
            }
        }
    }
}
