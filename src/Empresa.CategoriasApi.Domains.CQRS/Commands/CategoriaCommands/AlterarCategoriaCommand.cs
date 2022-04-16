using System;

namespace Empresa.CategoriasApi.Domains.CQRS.Commands.CategoriaCommands
{
    public class AlterarCategoriaCommand : CategoriaCommand
    {
        public AlterarCategoriaCommand(Guid id, string descricao)
            : base(id, descricao) { }
    }
}
