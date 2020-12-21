using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopWPF.Navigators;
using ShopWPF.ViewModels;
using ShopWPF.ViewModels.Factories;

namespace ShopWPF.Utils.Extensions.HostBuilderExtensions
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<EmployeeViewModel>();
                services.AddSingleton<SubdivisionViewModel>();
                services.AddSingleton<OrderViewModel>();
                services.AddSingleton<ProductViewModel>();

                services.AddSingleton<CreateViewModel<EmployeeViewModel>>(_ => _.GetRequiredService<EmployeeViewModel>);
                services.AddSingleton<CreateViewModel<SubdivisionViewModel>>(_ =>
                    _.GetRequiredService<SubdivisionViewModel>);
                services.AddSingleton<CreateViewModel<OrderViewModel>>(_ => _.GetRequiredService<OrderViewModel>);
                services.AddSingleton<CreateViewModel<ProductViewModel>>(_ => _.GetRequiredService<ProductViewModel>);

                services.AddSingleton<INavigator, Navigator>();
                services.AddSingleton<IShopViewModelFactory, ShopViewModelFactory>();
            });

            return host;
        }
    }
}