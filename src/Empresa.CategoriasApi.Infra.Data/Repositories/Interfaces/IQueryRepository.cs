using Empresa.CategoriasApi.Domains.Entities.Interfaces;
using Empresa.CategoriasApi.Domains.Interfaces.Repository;

namespace Empresa.CategoriasApi.Infra.Data.Repositories.Interfaces
{
    public interface IQueryRepository<T>
        : IQueryDomain<T> where T : IEntityBase { }
}
