using AutoMapper;
using Database;
using DataManager.EmployeeRepositories;
using DataManager.OrderRepositories;
using DataManager.ProductRepositories;
using DataManager.SubdivisionRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopWPF.Utils.MapperProfiles;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace ShopWPF.Utils.Extensions.HostBuilderExtensions
{
    public static class DefaultHostBuilderExtensions
    {
        public static IHostBuilder AddConfiguration(this IHostBuilder host)
        {
            host.ConfigureAppConfiguration(c =>
            {
                c.AddJsonFile("appsettings.json");
                c.AddEnvironmentVariables();
            });

            return host;
        }

        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
#if !STUB
            host.ConfigureServices((context, services) =>
            {
                var connectionString = context.Configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<ShopDbContext>(_ => _.UseMySQL(connectionString));
            });
#endif
            return host;
        }

        public static IHostBuilder AddAutoMapper(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<IConfigurationProvider>(_ =>
                    new MapperConfiguration(cfg => cfg.AddProfiles(new Profile[]
                    {
                        new ShopProfile()
                    })));

                services.AddSingleton<IMapper, Mapper>();
            });

            return host;
        }

        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
#if STUB
                services.AddSingleton<IEmployeeRepository, StubEmployeeRepository>();
                services.AddSingleton<ISubdivisionRepository, StubSubdivisionRepository>();
                services.AddSingleton<IOrderRepository, StubOrderRepository>();
                services.AddSingleton<IProductRepository, StubProductRepository>();
#else
                services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
                services.AddSingleton<ISubdivisionRepository, SubdivisionRepository>();
                services.AddSingleton<IOrderRepository, OrderRepository>();
                services.AddSingleton<IProductRepository, ProductRepository>();
#endif
            });

            return host;
        }
    }
}