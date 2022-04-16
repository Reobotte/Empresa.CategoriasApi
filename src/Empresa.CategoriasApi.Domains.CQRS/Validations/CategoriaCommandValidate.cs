namespace Empresa.CategoriasApi.Domains.CQRS.Validations
{
    class CategoriaCommandValidate : CategoriaValidate
    {
        internal CategoriaCommandValidate()
        {
            ValidarId();
            ValidarDescricao();
        }
    }
}
