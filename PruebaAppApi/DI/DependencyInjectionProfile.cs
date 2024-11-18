using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime;
using PruebaAppApi.DataAccess.Entities;
using PruebaAppApi.DataAccess.DataAccess;
using AplicationServices.ScopeService;
using AplicationServices.Application.Contracts.Helpers;
using AplicationServices.Helpers.Logger;
using AplicationServices.Application.Contracts.Orders;
using AplicationServices.Application.Orders;
using AplicationServices.Application.Contracts.Products;
using AplicationServices.Application.Products;
using DomainServices.Domain.Contracts.Orders;
using DomainServices.Domain.Orders;
using DomainServices.Domain.Products;
using DomainServices.Domain.Contracts.Products;
using AplicationServices.Application.Contracts.Authentication;
using AplicationServices.Application.Authentication;
using DomainServices.Domain.Contracts.User;
using DomainServices.Domain.User;



namespace PruebaAppApi.DI
{
    /// <summary>
    /// Provee la carga de los perfiles de inyección de dependencias
    /// de toda la solución
    /// </summary>
    public static class DependencyInjectionProfile
    {
        public static void RegisterProfile(IServiceCollection services, IConfiguration configuration)
        {
            #region Context

            CustomDbSettings val = new CustomDbSettings();


            services.AddDbContextFactory<LinkticEcomerceContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
                .LogTo(System.Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            });

            #endregion Context

            #region Application

            services.AddTransient<IOrdersAppServices, OrdersAppServices>();
            services.AddTransient<IProductsAppServices, ProductsAppServices>();
            services.AddTransient<IAuthenticationAppServices, AuthenticationAppServices>();

            #endregion

            #region Domain

            services.AddTransient<IOrdersDomain, OrdersDomain>();
            services.AddTransient<IProductsDomain, ProductsDomain>();
            services.AddTransient<IUserDomain, UserDomain>();

            #endregion Domain

            #region Others
            services.AddTransient<IServiceScopeDI, ServiceScope>();
            services.AddTransient<IServiceProvider, ServiceProvider>();
            //services.AddTransient<ILoggerServices, LoggerService>();
            #endregion
        }

    }
}
