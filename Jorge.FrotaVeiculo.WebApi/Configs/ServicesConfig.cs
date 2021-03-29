
using Jorge.FrotaVeiculo.Data.Context;
using Jorge.FrotaVeiculo.Domain.Interfaces.Repositories;
using Jorge.FrotaVeiculo.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;


namespace Jorge.FrotaVeiculo.WebApi.Configs
{
    public static class ServicesConfig
    {
        public static IServiceCollection AddRepositorios(this IServiceCollection serviceCollection)
        {

            serviceCollection.Scan(scan => scan
                .FromAssemblyOf<MainContext>()
                    .AddClasses(classes => classes.AssignableTo(typeof(IBaseRepository<>)))
                        .AsImplementedInterfaces()
                        .WithScopedLifetime()
            );

            return serviceCollection;
        }

        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {


            serviceCollection.Scan(scan => scan
                .FromAssembliesOf(typeof(IBaseService<>))
                    .AddClasses(classes => classes.AssignableTo(typeof(IBaseService<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
            );

            return serviceCollection;
        }

        
    }
}