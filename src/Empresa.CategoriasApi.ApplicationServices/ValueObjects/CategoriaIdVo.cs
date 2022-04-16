using Empresa.CategoriasApi.Domains.Entities.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Empresa.CategoriasApi.ApplicationServices.ValueObjects
{
    public class CategoriaIdVo : CategoriaVo, IEntityBase
    {
        [Required(ErrorMessage = "O {0} é obrigatório!")]
        [DisplayName("Id")]
        public Guid Id { get; set; }

        private CategoriaIdVo() { }

        internal CategoriaIdVo(Guid id) =>
            Id = id;
    }
}
