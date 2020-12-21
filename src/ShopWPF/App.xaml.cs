using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopWPF.Utils.Extensions.HostBuilderExtensions;
using ShopWPF.Views;

namespace ShopWPF
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null) =>
            Host.CreateDefaultBuilder(args)
                .AddConfiguration()
                .AddDbContext()
                .AddAutoMapper()
                .AddServices()
                .AddViewModels()
                .AddViews();

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            var mainView = _host.Services.GetRequiredService<MainView>();
            mainView.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}