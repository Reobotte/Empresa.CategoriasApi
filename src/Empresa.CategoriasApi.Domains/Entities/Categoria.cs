using Empresa.CategoriasApi.Domains.Entities.Interfaces;
using System;

namespace Empresa.CategoriasApi.Domains.Entities
{
    public class Categoria : EntityBase, ICategoria
    {
        public string Descricao { get; private set; }

        private Categoria() : base() { }

        protected Categoria(Guid id)
            : base(id) { }

        protected Categoria(string descricao) =>
            Set(descricao: descricao);

        protected Categoria(Guid id, string descricao)
            : base(id) =>
                Set(descricao: descricao);

        public Categoria(ICategoria entity) : base(entity.Id) =>
            Set(descricao: entity.Descricao);

        private void Set(string descricao) =>
            Descricao = descricao;

        public override string ToString() =>
            Id.ToString() + "  -  " + Descricao;
    }
}
