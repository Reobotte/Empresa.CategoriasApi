using Empresa.CategoriasApi.Domains.Interfaces.Repository;
using Empresa.CategoriasApi.Infra.Data.ORM.EFCore;
using System.Threading.Tasks;

namespace Empresa.CategoriasApi.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CategoriaDbContext _context;

        public UnitOfWork(CategoriaDbContext context) =>
            _context = context;

        public async Task<bool> Commit() =>
            await _context.SaveChangesAsync() > 0;
    }
}
