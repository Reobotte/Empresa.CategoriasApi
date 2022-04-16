using AutoMapper;
using Empresa.CategoriasApi.ApplicationServices.Interfaces;
using Empresa.CategoriasApi.ApplicationServices.ValueObjects;
using Empresa.CategoriasApi.Domains.CQRS.Commands.CategoriaCommands;
using Empresa.CategoriasApi.Domains.CQRS.Core.Validations;
using Empresa.CategoriasApi.Infra.Data.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.CategoriasApi.ApplicationServices
{
    public class CategoriaApplicationService
        : ICategoriaApplicationService
    {
        private readonly ICategoriaQueryRepository _query;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoriaApplicationService(
            ICategoriaQueryRepository query,
            IMapper mapper,
            IMediator mediator)
        {
            _query = query;
            _mediator = mediator;
            _mapper = mapper;
        }

        #region Query

        public async Task<IEnumerable<CategoriaIdVo>> GetAll() =>
            _mapper.Map<IEnumerable<CategoriaIdVo>>(
                await _query.GetAll());

        public async Task<CategoriaIdVo> Get(Guid id) =>
            _mapper.Map<CategoriaIdVo>(
                await _query.Get(id));

        #endregion

        #region CRUD

        public async Task<ResultVo> Insert(CategoriaIdVo obj) =>
            await GetResultVo(
                categoriaCommand: _mapper.Map<IncluirCategoriaCommand>(obj));

        public async Task<ResultVo> Update(CategoriaIdVo obj) =>
            await GetResultVo(
                categoriaCommand: _mapper.Map<AlterarCategoriaCommand>(obj));

        public async Task<IResult> Delete(Guid id) =>
            await _mediator.Send(
                _mapper.Map<ExcluirCategoriaCommand>(new CategoriaIdVo(id)));

        private async Task<ResultVo> GetResultVo(CategoriaCommand categoriaCommand) =>
            new ResultVo(
                result: await _mediator.Send(categoriaCommand),
                categoriaIdVo: _mapper.Map<CategoriaIdVo>(categoriaCommand));

        #endregion

        public void Dispose() =>
            _query?.Dispose();
    }
}
