using Empresa.CategoriasApi.Domains.Entities;
using Empresa.CategoriasApi.Domains.Entities.Interfaces;
using Empresa.CategoriasApi.Domains.Interfaces.Repository;
using Empresa.CategoriasApi.Infra.Data.ORM.EFCore;
using Empresa.CategoriasApi.Infra.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.CategoriasApi.Infra.Data.Repositories
{
    public class CategoriaRepository
        : Repository<Categoria>, ICategoriaRepository,
        ICategoriaQueryRepository, ICategoriaQueryDomain
    {
        public CategoriaRepository(CategoriaDbContext context)
            : base(context) { }

        #region Query

        async Task<IEnumerable<ICategoria>> IQueryDomain<ICategoria>.GetAll() =>
            await base.GetAll();

        async Task<ICategoria> IQueryDomain<ICategoria>.Get(Guid id) =>
            await Get(id);

        #endregion

        #region CRUD

        public void Insert(ICategoria obj) =>
            base.Insert((Categoria)obj);

        public void Update(ICategoria obj) =>
            base.Update((Categoria)obj);

        public void Delete(ICategoria obj) =>
            base.Delete((Categoria)obj);

        #endregion
    }
}
