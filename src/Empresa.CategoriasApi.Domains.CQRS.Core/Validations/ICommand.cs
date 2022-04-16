namespace Empresa.CategoriasApi.Domains.CQRS.Core.Validations
{
    public interface ICommand
    {
        bool IsValid();
    }
}
