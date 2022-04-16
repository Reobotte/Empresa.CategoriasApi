using Empresa.CategoriasApi.Domains.Entities.Interfaces;

namespace Empresa.CategoriasApi.Domains.Interfaces.Repository
{
    public interface ICommandRepository<T>
        : IRepository<T> where T : IEntityBase
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
