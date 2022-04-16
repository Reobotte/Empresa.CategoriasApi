using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Empresa.CategoriasApi.ApplicationServices.ValueObjects
{
    public class CategoriaVo
    {
        [Required(ErrorMessage = "A {0} é obrigatória!")]
        [StringLength(80, ErrorMessage = "A {0} deve ter possuir entre {2} a {1} caracteres!", MinimumLength = 3)]
        [DisplayName("Categoria")]
        public string Descricao { get; set; }
    }
}
