using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Framework.Message.Concrete;
using TesteAnkix.Webapi.Application.Queries.Country;

namespace TesteAnkix.Webapi.Application.Configurations
{
    public static class DependencyConfiguration
    {
        public static void ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            AssemblyScanner.FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
                           .ForEach(r => services.AddScoped(r.InterfaceType, r.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestBehavior<,>));

            services.AddScoped<ICountryQuery, CountryQuery>();
            services.AddSingleton(configuration);
            
        }
    }
}

