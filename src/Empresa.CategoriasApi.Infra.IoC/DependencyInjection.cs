using Empresa.CategoriasApi.ApplicationServices;
using Empresa.CategoriasApi.ApplicationServices.Interfaces;
using Empresa.CategoriasApi.Domains.Interfaces.Repository;
using Empresa.CategoriasApi.Infra.Data.Repositories;
using Empresa.CategoriasApi.Infra.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Empresa.CategoriasApi.Infra.IoC
{
    public static class DependencyInjection
    {
        public static void AddDependency(
            this IServiceCollection services)
        {
            services.AddScoped<ICategoriaApplicationService, CategoriaApplicationService>();
            services.AddScoped<ICategoriaQueryRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaQueryDomain, CategoriaRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
