using Empresa.CategoriasApi.Domains.CQRS.Core.Handlers;
using Empresa.CategoriasApi.Domains.CQRS.Core.Validations;
using Empresa.CategoriasApi.Domains.Entities;
using Empresa.CategoriasApi.Domains.Entities.Interfaces;
using Empresa.CategoriasApi.Domains.Interfaces.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Empresa.CategoriasApi.Domains.CQRS.Handlers
{
    internal class CategoriaHandler
        : HandlerMessage
    {
        private readonly ICategoriaQueryDomain _categoriaQueryDomain;
        private readonly ICategoriaRepository _repository;
        private readonly IValidateCommand _validateCommand;

        internal CategoriaHandler(
            ICategoriaRepository repository,
            ICategoriaQueryDomain categoriaQueryDomain,
            IValidateCommand validateCommand,
            CancellationToken cancellationToken,
            IMediator mediator)
                : base(cancellationToken, mediator)
        {
            _repository = repository;
            _categoriaQueryDomain = categoriaQueryDomain;
            _validateCommand = validateCommand;
        }

        internal async Task<Result> Results()
        {
            var result = new Result();
            if (_validateCommand.IsValid())
            {
                var entity = (ICategoria)_validateCommand;
                await CommandsExecute<ICategoria>
                    .Commands(
                        request: _validateCommand,
                        response: await _categoriaQueryDomain.Get(entity.Id),
                        repository: _repository,
                        requested: new Categoria(entity),
                        result: result,
                        handlerMessage: this);
            }
            else
                await ErrorRequestAsync(_validateCommand.ValidationResult, result);

            return result;
        }
    }
}
