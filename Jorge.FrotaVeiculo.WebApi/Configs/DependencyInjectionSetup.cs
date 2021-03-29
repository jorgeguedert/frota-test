using Jorge.FrotaVeiculo.WebApi.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Jorge.FrotaVeiculo.WebApi.WebApi.Configs
{
    public static class DependencyInjectionSetup
    {
        public static IServiceProvider AddDependencyInjectionSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services is null) throw new ArgumentNullException(nameof(services));

            if (configuration is null) throw new ArgumentException(nameof(configuration));

            NativeInjectorBootStrapper.Configure(services, configuration);

            return services.BuildServiceProvider();
        }
    }
}
