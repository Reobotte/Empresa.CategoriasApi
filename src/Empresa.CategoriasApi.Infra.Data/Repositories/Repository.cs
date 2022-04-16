using Empresa.CategoriasApi.Domains.Entities.Interfaces;
using Empresa.CategoriasApi.Domains.Interfaces.Repository;
using Empresa.CategoriasApi.Infra.Data.ORM.EFCore;
using Empresa.CategoriasApi.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.CategoriasApi.Infra.Data.Repositories
{
    public abstract class Repository<T>
        : RepositoryBase<T>, IQueryDomain<T>,
        ICommandRepository<T>, IQueryRepository<T>
        where T : class, IEntityBase
    {
        private readonly DbSet<T> _entity;

        protected Repository(CategoriaDbContext context)
            : base(context) =>
                _entity = Context.Set<T>();

        #region Query

        public virtual async Task<IEnumerable<T>> GetAll() =>
            await _entity
                .AsNoTracking()
                .ToListAsync();

        public async Task<T> Get(Guid id) =>
            await _entity
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);

        #endregion

        #region CRUD

        public void Insert(T obj) =>
            _entity.Add(obj).State = EntityState.Added;

        public void Update(T obj) =>
            Context.Entry(obj).State = EntityState.Modified;

        public void Delete(T obj) =>
            _entity.Remove(obj);

        #endregion
    }
}
