using Microsoft.Extensions.DependencyInjection;
using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Service;
using SimReeferMiddlewareSystemWPF.Store;
using SimReeferMiddlewareSystemWPF.View;
using SimReeferMiddlewareSystemWPF.ViewModel;
using SimReeferMiddlewareSystemWPF.ViewModel.Menu;
using SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver10;
using SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver8;
using SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver9;
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
            services.AddSingleton<DeviceFirmwareInfoStore>();
            services.AddSingleton<IDGenerateInfoStore>();
            services.AddSingleton<IDGenerateInfoCreateStore>();
            services.AddSingleton<IDGenerateInfoRegistStore>();

            //Service
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IMessageBoxService, MessageBoxService>();
            services.AddSingleton<IModelDataService, ModelDataService>();
            services.AddScoped<ITcpSocketService, TcpSocketService>();
            services.AddSingleton<ITableBuilderService, TableBuilderService>();

            //ViewModels
            services.AddSingleton<MainViewModel>();

            services.AddTransient<ProtocolViewModelVer8>();
            services.AddTransient<DeviceInfoViewModelVer8>();
            services.AddTransient<SetupInfoViewModelVer8>();
            services.AddTransient<DeviceBodyViewModelVer8>();
            services.AddTransient<ReeferBodyViewModelVer8>();

            services.AddTransient<ProtocolViewModelVer9>();
            services.AddTransient<DeviceInfoViewModelVer9>();
            services.AddTransient<SetupInfoViewModelVer9>();
            services.AddTransient<DeviceBodyViewModelVer9>();
            services.AddTransient<ReeferBodyViewModelVer9>();
            services.AddTransient<SensorBodyViewModelVer9>();

            services.AddTransient<ProtocolViewModelVer10>();
            services.AddTransient<DeviceInfoViewModelVer10>();
            services.AddTransient<SetupInfoViewModelVer10>();
            services.AddTransient<DeviceBodyViewModelVer10>();
            services.AddTransient<ReeferBodyViewModelVer10>();
            services.AddTransient<SensorBodyViewModelVer10>();

            services.AddTransient<SendManualViewModel>();
            services.AddTransient<FOTAServerViewModel>();
            services.AddTransient<FOTAServerPacketViewModel>();
            services.AddTransient<IDGenerateServerViewModel>();
            services.AddTransient<IDGenerateServerCreatePacketViewModel>();
            services.AddTransient<IDGenerateServerRegistPacketViewModel>();

            //Views
            services.AddSingleton(s => new MainView()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            return services.BuildServiceProvider();
        }
    }

}
