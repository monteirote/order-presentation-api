using Microsoft.AspNetCore.Mvc;
using OrderPresentationApi.Services;
using OrderPresentationApi.ViewModels;

namespace OrderPresentationApi.Controllers {

    [ApiController]
    [Route("api/quadros")]
    public class QuadroController : ControllerBase {

        private readonly IQuadroService _quadroService;

        public QuadroController (IQuadroService quadroService) {
            _quadroService = quadroService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll () {
            var quadros = await _quadroService.FindAll();
            return Ok(quadros);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById (int id) {
            var quadro = await _quadroService.FindById(id);

            if (quadro is null)
                return NotFound();

            return Ok(quadro);
        }


        [HttpPost]
        public async Task<IActionResult> Post (QuadroViewModel novoQuadro) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var novoMaterial = await _quadroService.Create(novoQuadro);

            if (novoMaterial is null)
                return BadRequest("Esse ID não corresponde a nenhum Tipo de Material.");

            return CreatedAtAction(nameof(GetById), new { id = novoMaterial.ID }, novoMaterial);
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update (int id, QuadroViewModel novoQuadro) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _quadroService.Update(id, novoQuadro);

            return success ? NoContent() : NotFound();
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete (int id) {
            return await _quadroService.Delete(id) ? NoContent() : NotFound();
        }
    }
}
