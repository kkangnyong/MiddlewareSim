using Microsoft.Extensions.DependencyInjection;
using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Service;
using SimReeferMiddlewareSystemWPF.Store;
using SimReeferMiddlewareSystemWPF.View;
using SimReeferMiddlewareSystemWPF.ViewModel;
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

            //Service
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IMessageBoxService, MessageBoxService>();
            services.AddSingleton<IModelData, ModelDataService>();

            //ViewModels
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<ProtocolViewModel>();
            services.AddSingleton<DeviceInfoViewModel>();
            services.AddSingleton<SetupInfoViewModel>();
            services.AddSingleton<DeviceBodyViewModel>();
            services.AddSingleton<ReeferBodyViewModel>();

            //Views
            services.AddSingleton(s => new MainView()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            return services.BuildServiceProvider();
        }
    }

}
