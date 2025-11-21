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
            services.AddSingleton<SensorBodyStore>();
            services.AddSingleton<ServerConnectionStore>();

            //Service
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IMessageBoxService, MessageBoxService>();
            services.AddSingleton<IModelDataService, ModelDataService>();
            services.AddScoped<ITcpSocketService, TcpSocketService>();
            services.AddSingleton<IUIControlService, UIControlService>();

            //ViewModels
            services.AddSingleton<MainViewModel>();
            services.AddTransient<ProtocolViewModelVer8>();
            services.AddTransient<DeviceInfoViewModelVer8>();
            services.AddTransient<SetupInfoViewModelVer8>();
            services.AddTransient<DeviceBodyViewModelVer8>();
            services.AddTransient<ReeferBodyViewModelVer8>();

            //Views
            services.AddSingleton(s => new MainView()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            return services.BuildServiceProvider();
        }
    }

}
