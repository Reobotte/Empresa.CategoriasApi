﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Empresa.CategoriasApi.Infra.Data.ORM.EFCore
{
    class ContextFactory : IDesignTimeDbContextFactory<CategoriaDbContext>
    {
        public CategoriaDbContext CreateDbContext(string[] args)
        {
            var opt = new DbContextOptionsBuilder<CategoriaDbContext>();
            opt.UseMySql("Server=yjo6uubt3u5c16az.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;Port=3306;Database=e7qur4x1chzgk8be;Uid=s1c2qcinrywt056s;Pwd=oh4wvovz9gjmfqce");
            return new CategoriaDbContext(opt.Options);
        }
    }
}
