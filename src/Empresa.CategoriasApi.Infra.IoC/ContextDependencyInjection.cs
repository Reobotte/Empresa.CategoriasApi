using Empresa.CategoriasApi.Infra.Data.ORM.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Empresa.CategoriasApi.Infra.IoC
{
    public static class ContextDependencyInjection
    {
        public static void AddContextDependency(
            this IServiceCollection services, IConfiguration configuration) =>
                services.AddDbContext<CategoriaDbContext>(opt => opt.UseMySql(configuration["ConnectionStrings:CategoriaConnection"]));
    }
}
