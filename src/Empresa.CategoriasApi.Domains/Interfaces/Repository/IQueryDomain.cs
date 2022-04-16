﻿using Empresa.CategoriasApi.Domains.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.CategoriasApi.Domains.Interfaces.Repository
{
    public interface IQueryDomain<T>
        : IRepository<T> where T : IEntityBase
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid id);
    }
}
