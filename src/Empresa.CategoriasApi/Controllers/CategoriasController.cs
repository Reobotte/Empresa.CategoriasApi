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
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAll() =>
            Ok();

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put(Guid id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return NoContent();
        }

        #region Private Methods

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
