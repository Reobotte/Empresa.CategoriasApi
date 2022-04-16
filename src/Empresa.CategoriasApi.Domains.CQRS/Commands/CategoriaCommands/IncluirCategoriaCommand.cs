namespace Empresa.CategoriasApi.Domains.CQRS.Commands.CategoriaCommands
{
    public class IncluirCategoriaCommand : CategoriaCommand
    {
        public IncluirCategoriaCommand(string descricao)
            : base(descricao) { }
    }
}
