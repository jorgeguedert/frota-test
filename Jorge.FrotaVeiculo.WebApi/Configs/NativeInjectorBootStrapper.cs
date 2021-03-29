using Jorge.FrotaVeiculo.Data;
using Jorge.FrotaVeiculo.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Jorge.FrotaVeiculo.WebApi.Configs
{
    public class NativeInjectorBootStrapper
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            //ConfigureSingletonServices.Configure(services, configuration);
            //ConfigureExclusionServices.Configure(services, configuration);

            var apiAssembly = Assembly.GetExecutingAssembly();
            var domainAssembly = Assembly.GetAssembly(typeof(DomainSample));
            var dataAssembly = Assembly.GetAssembly(typeof(DataSample));

            Register(services, apiAssembly);
            Register(services, domainAssembly);
            Register(services, dataAssembly);
        }

        private static void Register(IServiceCollection services, Assembly assembly)
        {
            var implementations = assembly.GetTypes()
                .Where(a =>
                    a.IsClass &&
                    !a.IsAbstract);

            foreach (var implementation in implementations)
            {
                var contract = implementation.GetInterfaces()
                        .FirstOrDefault(i => i.IsInterface && i.Name == $"I{implementation.Name}");

                if (contract is null)
                    continue;

                if (services.Any(x => x.ServiceType == contract))
                    continue;

                if (contract.IsGenericType && services.Any(x => x.ServiceType == contract.GetGenericTypeDefinition()))
                    continue;

                if (contract.IsGenericType)
                {
                    services.AddScoped(contract.GetGenericTypeDefinition(), implementation.GetGenericTypeDefinition());
                    continue;
                }

                services.AddScoped(contract, implementation);
            }
        }


    }
}
