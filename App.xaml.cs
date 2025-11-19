using Microsoft.Extensions.DependencyInjection;
using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Service;
using SimReeferMiddlewareSystemWPF.Store;
using SimReeferMiddlewareSystemWPF.View;
using SimReeferMiddlewareSystemWPF.ViewModel;
using SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver8;
using System.Windows;

namespace SimReeferMiddlewareSystemWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;

        public IServiceProvider Services { get; }

        public App()
        { 
            Services = ConfigureServices();
            var mainView = Services.GetRequiredService<MainView>();
            mainView.Show();
        }

        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            //Store
            services.AddSingleton<MainNavigationStore>();
            services.AddSingleton<DeviceInfoStore>();
            services.AddSingleton<SetupInfoStore>();
            services.AddSingleton<DeviceBodyStore>();
            services.AddSingleton<ReeferBodyStore>();

            //Service
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IMessageBoxService, MessageBoxService>();
            services.AddSingleton<IModelData, ModelDataService>();

            //ViewModels
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<ProtocolViewModelVer8>();
            services.AddSingleton<DeviceInfoViewModelVer8>();
            services.AddSingleton<SetupInfoViewModelVer8>();
            services.AddSingleton<DeviceBodyViewModelVer8>();
            services.AddSingleton<ReeferBodyViewModelVer8>();

            //Views
            services.AddSingleton(s => new MainView()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            return services.BuildServiceProvider();
        }
    }

}
