using SimReeferMiddlewareSystemWPF.ViewModel;
using System.ComponentModel;

namespace SimReeferMiddlewareSystemWPF.Store
{
    public class MainNavigationStore : ViewModelBase
    {
        private INotifyPropertyChanged? _currentViewModel;

		public INotifyPropertyChanged? CurrentViewModel
		{
			get { return _currentViewModel; }
			set { _currentViewModel = value;
				CurrentViewModelChanged?.Invoke();
                _currentViewModel = null;
            }
        }
        public Action? CurrentViewModelChanged { get; set; }
    }
}
