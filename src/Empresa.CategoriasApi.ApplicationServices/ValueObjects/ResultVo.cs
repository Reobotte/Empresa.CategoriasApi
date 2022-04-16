using Empresa.CategoriasApi.Domains.CQRS.Core.Validations;

namespace Empresa.CategoriasApi.ApplicationServices.ValueObjects
{
    public class ResultVo
    {
        public IResult Result { get; set; }
        public CategoriaIdVo CategoriaIdVo { get; set; }
        public ResultVo(IResult result, CategoriaIdVo categoriaIdVo)
        {
            Result = result;
            CategoriaIdVo = categoriaIdVo;
        }
    }
}
