using Empresa.CategoriasApi.Domains.CQRS.Commands.CategoriaCommands;
using Empresa.CategoriasApi.Domains.CQRS.Core.Validations;
using Empresa.CategoriasApi.Domains.Interfaces.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Empresa.CategoriasApi.Domains.CQRS.Handlers
{
    public class Handler
        : ICategoriaHandler
    {
        private readonly IMediator _mediator;
        private readonly ICategoriaRepository _repository;
        private readonly ICategoriaQueryDomain _query;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(
            IMediator mediator,
            ICategoriaRepository repository,
            ICategoriaQueryDomain query,
            IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _repository = repository;
            _query = query;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(IncluirCategoriaCommand request, CancellationToken cancellationToken)
        {
            var results = await ProdutoResult(request, cancellationToken);
            // ToDo : Regras de negocio antes de comitar
            if (!results.HasErrors)
                await _unitOfWork.Commit();

            return results;
        }

        public async Task<Result> Handle(AlterarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var results = await ProdutoResult(request, cancellationToken);
            // ToDo : Regras de negocio antes de comitar
            if (!results.HasErrors)
                await _unitOfWork.Commit();

            return results;
        }

        public async Task<Result> Handle(ExcluirCategoriaCommand request, CancellationToken cancellationToken)
        {
            var results = await ProdutoResult(request, cancellationToken);
            // ToDo : Regras de negocio antes de comitar
            if (!results.HasErrors)
                await _unitOfWork.Commit();

            return results;
        }

        private async Task<Result> ProdutoResult(IValidateCommand request, CancellationToken cancellationToken) =>
            await new CategoriaHandler(
                repository: _repository,
                categoriaQueryDomain: _query,
                validateCommand: request,
                cancellationToken: cancellationToken,
                mediator: _mediator).Results();
    }
}
