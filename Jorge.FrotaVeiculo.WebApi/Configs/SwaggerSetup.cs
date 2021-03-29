using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jorge.FrotaVeiculo.WebApi.Configurations
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Teste Jorge Frota de Veiculos",
                    Description = "API do Teste Jorge Frota de Veiculos",
                    Contact = new OpenApiContact
                    {
                        Name = "Jorge",
                        Email = "jorge_guedert@hotmail.com",
                    }
                });

                s.ResolveConflictingActions(resolver =>
                {
                    if (resolver.Any(x => x.ActionDescriptor?.AttributeRouteInfo is null))
                        throw new Exception();

                    var menorOrdem = resolver.Min(x => x.ActionDescriptor.AttributeRouteInfo.Order);

                    if (resolver.Count(x => x.ActionDescriptor.AttributeRouteInfo.Order == menorOrdem) > 1)
                        throw new Exception();

                    return resolver.First(x => x.ActionDescriptor.AttributeRouteInfo.Order == menorOrdem);
                });

            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/swagger.json", "Frota Veiculos Teste Jorge");
            });
        }
    }
}
