using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Store;
using SimReeferMiddlewareSystemWPF.ViewModel;
using SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver8;
using SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver9;
using SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver10;
using System.ComponentModel;
using Mythosia;
using SimReeferMiddlewareSystemWPF.View.Menu;
using SimReeferMiddlewareSystemWPF.ViewModel.Menu;

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

        public void Navigate(NaviType type, string protocolVer = "")
        {
            switch (type)
            {
                case NaviType.DeviceBodyView:
                    if (protocolVer.Equals(ProtocolVerType.V8.ToDescription()))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(DeviceBodyViewModelVer8));
                    }
                    else if (protocolVer.Equals(ProtocolVerType.V9.ToDescription()))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(DeviceBodyViewModelVer9));
                    }
                    else if (protocolVer.Equals(ProtocolVerType.V10.ToDescription()))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(DeviceBodyViewModelVer10));
                    }
                    break;
                case NaviType.DeviceInfoView:
                    if (protocolVer.Equals(ProtocolVerType.V8.ToDescription()))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(DeviceInfoViewModelVer8));
                    }
                    else if (protocolVer.Equals(ProtocolVerType.V9.ToDescription()))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(DeviceInfoViewModelVer9));
                    }
                    else if (protocolVer.Equals(ProtocolVerType.V10.ToDescription()))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(DeviceInfoViewModelVer10));
                    }
                    break;
                case NaviType.ReeferBodyView:
                    if (protocolVer.Equals(ProtocolVerType.V8.ToDescription()))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(ReeferBodyViewModelVer8));
                    }
                    else if (protocolVer.Equals(ProtocolVerType.V9.ToDescription()))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(ReeferBodyViewModelVer9));
                    }
                    else if (protocolVer.Equals(ProtocolVerType.V10.ToDescription()))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(ReeferBodyViewModelVer10));
                    }
                    break;
                case NaviType.SetupInfoView:
                    if (protocolVer.Equals(ProtocolVerType.V8.ToDescription()))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(SetupInfoViewModelVer8));
                    }
                    else if (protocolVer.Equals(ProtocolVerType.V9.ToDescription()))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(SetupInfoViewModelVer9));
                    }
                    else if (protocolVer.Equals(ProtocolVerType.V10.ToDescription()))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(SetupInfoViewModelVer10));
                    }
                    break;
                case NaviType.SensorBodyView:
                    if (protocolVer.Equals(ProtocolVerType.V9.ToDescription()))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(SensorBodyViewModelVer9));
                    }
                    else if (protocolVer.Equals(ProtocolVerType.V10.ToDescription()))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(SensorBodyViewModelVer10));
                    }
                    break;
                case NaviType.SendManualView:
                      CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(SendManualViewModel));
                    break;
                default:
                    if (protocolVer.Equals(ProtocolVerType.V8.ToDescription()))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(ProtocolViewModelVer8));
                    }
                    else if (protocolVer.Equals(ProtocolVerType.V9.ToDescription()))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(ProtocolViewModelVer9));
                    }
                    else if (protocolVer.Equals(ProtocolVerType.V10.ToDescription()))
                    {
                        CurrentViewModel = (ViewModelBase)App.Current.Services.GetService(typeof(ProtocolViewModelVer10));
                    }
                    break;
            }
        }
    }
}
