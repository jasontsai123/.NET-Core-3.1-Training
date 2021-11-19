using System.Net.Http;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Training2020WithNorthwind.Application.Infrastructure.Mappings;
using Training2020WithNorthwind.Repository.Implements;
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
                .Decorate<ICustomersRepository, TryCatchCustomersRepository>();

            services.AddSingleton<HttpClient>();

            return services;
        }
    }
}