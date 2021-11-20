using System.Net.Http;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Training2020WithNorthwind.Application.Infrastructure.Mappings;
using Training2020WithNorthwind.Common.Infrastructure.Caching;
using Training2020WithNorthwind.Repository.Implements;
using Training2020WithNorthwind.Repository.Implements.Decorators;
using Training2020WithNorthwind.Repository.Implements.Interfaces;
using Training2020WithNorthwind.Repository.Infrastructure.Constants;
using Training2020WithNorthwind.Repository.Infrastructure.Constants.Interfaces;
using Training2020WithNorthwind.Repository.Infrastructure.Helpers;
using Training2020WithNorthwind.Repository.Infrastructure.Helpers.Interfaces;
using Training2020WithNorthwind.Service.Implements;
using Training2020WithNorthwind.Service.Implements.Interfaces;
using Training2020WithNorthwind.Service.Infrastructure.Mappings;

namespace Training2020WithNorthwind.Application.Infrastructure.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            // Setting
            services.AddSingleton<IDatabaseConstants, DatabaseConstants>();

            // Helper
            services.AddSingleton<IDatabaseHelper, DatabaseHelper>();

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ServiceProfile());
                mc.AddProfile(new ApplicationProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            //Service
            services.AddScoped<ICustomerService, CustomerService>();

            //Repository
            services.AddScoped<ICustomersRepository, CustomersRepository>()
                .Decorate<ICustomersRepository, TryCatchCustomersRepository>()
                .Decorate<ICustomersRepository, CachedCustomersRepository>();

            services.AddSingleton<HttpClient>();

            //Cache
            services.AddDistributedMemoryCache();
            //services.AddStackExchangeRedisCache(options =>
            //{
            //    // Redis Server 的 IP 跟 Port
            //    options.Configuration = "127.0.0.1:6379";
            //});
            services.AddScoped<ICacheProvider, CacheProvider>();

            return services;
        }
    }
}