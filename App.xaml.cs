using Microsoft.Extensions.DependencyInjection;
using SimReeferMiddlewareSystemWPF.Inteface;
using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Store;
using SimReeferMiddlewareSystemWPF.Service;
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

            //Service
            services.AddSingleton<INavigationService, NavigationService>();

            //ViewModels
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<ProtocolViewModel>();
            services.AddSingleton<DeviceBodyViewModel>();
            services.AddSingleton<SetupInfoViewModel>();
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
