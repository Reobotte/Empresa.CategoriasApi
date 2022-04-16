using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Empresa.CategoriasApi.Infra.IoC
{
    public static class OthersDependencyInjection
    {
        public static void AddOthersDependency(
            this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.Load("Empresa.CategoriasApi.ApplicationServices"));
            services.AddMediatR(Assembly.Load("Empresa.CategoriasApi.Domains.CQRS"));
        }
    }
}
