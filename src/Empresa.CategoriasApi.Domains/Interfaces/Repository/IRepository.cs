using Empresa.CategoriasApi.Domains.Entities.Interfaces;
using System;

namespace Empresa.CategoriasApi.Domains.Interfaces.Repository
{
    public interface IRepository<T>
        : IDisposable where T : IEntityBase { }
}
