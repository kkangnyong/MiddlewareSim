using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Store;
using System.ComponentModel;

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
        private readonly MainNavigationStore? _mainNavigationStore;

        public MainViewModel(MainNavigationStore mainNavigationStore, INavigationService navigationService)
        {
            _mainNavigationStore = mainNavigationStore;
            _mainNavigationStore.CurrentViewModelChanged += CurrentViewModelChanged;
            navigationService.Navigate(Service.NaviType.ProtocolView);
        }

        private void CurrentViewModelChanged()
        {
            CurrentViewModel = _mainNavigationStore?.CurrentViewModel;
        }
    }
}
