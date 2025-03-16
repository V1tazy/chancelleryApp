using chancelleryApp.Data;
using chancelleryApp.Services;
using chancelleryApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace chancelleryApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IHost _Host;


        public static IHost Host => _Host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => _Host.Services;

        internal static void ConfigureService(HostBuilderContext host, IServiceCollection services) => services
            .AddDatabase()
            .AddService()
            .AddViewModel();

        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;

            base.OnStartup(e);

            await host.StartAsync();    
        }


        protected override async void OnExit(ExitEventArgs e)
        {
            using var host = Host;
            base.OnExit(e);

            await host.StopAsync();
        }
    }

}
