using AutoMapper;
using Empresa.CategoriasApi.ApplicationServices.Interfaces;
using Empresa.CategoriasApi.ApplicationServices.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.CategoriasApi.Controllers
{
    // ToDo: Implementar gerenciamento para controle de versão
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaApplicationService _service;

        public CategoriasController(ICategoriaApplicationService service) =>
            _service = service;

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAll());

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(CategoriaIdVo))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _service.Get(id);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(204, Type = typeof(CategoriaVo))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post(
            [FromBody] CategoriaVo categoriaVo, [FromServices] IMapper _mapper)
        {
            if (categoriaVo == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.Insert(_mapper.Map<CategoriaIdVo>(categoriaVo));
            if (result.Result.HasErrors)
                return Resultado(result: result.Result.Errors);

            return GetCreatedAtRoute(categoriaIdVo: result.CategoriaIdVo);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(CategoriaIdVo))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put(
            Guid id,
            [FromBody] CategoriaIdVo categoriaIdVo)
        {
            if (id != categoriaIdVo.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.Update(categoriaIdVo);
            if (result.Result.HasErrors)
                return Resultado(result: result.Result.Errors);

            return GetCreatedAtRoute(categoriaIdVo: result.CategoriaIdVo);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _service.Delete(id);
            if (response.HasErrors)
                return Resultado(result: response.Errors);

            return NoContent();
        }

        #region Private Methods

        private CreatedAtRouteResult GetCreatedAtRoute(CategoriaIdVo categoriaIdVo)
        {
            return CreatedAtRoute(
                "DefaultApi",
                new { categoria = categoriaIdVo, get = GetLink(id: categoriaIdVo.Id) });
        }

        private string GetLink(Guid id) =>
            new StringBuilder(Url.Link("DefaultApi", new { id }))
                .Replace("%2F", "/")
                .ToString();

        private IActionResult Resultado(IEnumerable<string> result)
        {
            AddModelError(result.ToList());
            return BadRequest(ModelState);
        }

        private void AddModelError(List<string> erros) =>
            erros.ToList()
                .ForEach(erro => ModelState.AddModelError(string.Empty, erro));

        #endregion
    }
}
