using System.Threading.Tasks;

namespace Empresa.CategoriasApi.Domains.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
