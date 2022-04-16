using Empresa.CategoriasApi.Domains.Entities.Interfaces;
using System;

namespace Empresa.CategoriasApi.ApplicationServices.Interfaces
{
    public interface IApplicationServiceBase<T>
        : IDisposable where T : IEntityBase { }
}
