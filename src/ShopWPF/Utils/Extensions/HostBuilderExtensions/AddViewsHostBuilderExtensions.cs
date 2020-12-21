using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopWPF.ViewModels;
using ShopWPF.Views;

namespace ShopWPF.Utils.Extensions.HostBuilderExtensions
{
    public static class AddViewsHostBuilderExtensions
    {
        public static IHostBuilder AddViews(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton(s => new MainView(s.GetRequiredService<MainViewModel>()));
            });

            return host;
        }
    }
}