using Empresa.CategoriasApi.Domains.Entities.Interfaces;
using Empresa.CategoriasApi.Domains.Interfaces.Repository;
using Empresa.CategoriasApi.Infra.Data.ORM.EFCore;

namespace Empresa.CategoriasApi.Infra.Data.Repositories
{
    public abstract class RepositoryBase<T>
        : IRepository<T> where T : IEntityBase
    {
        protected readonly CategoriaDbContext Context;

        protected RepositoryBase(CategoriaDbContext context) =>
            Context = context;

        public void Dispose() =>
            Context?.DisposeAsync().AsTask();
    }
}
