using Microsoft.AspNetCore.Mvc;
using OrderPresentationApi.Repositories;
using OrderPresentationApi.Services;
using OrderPresentationApi.ViewModels;

namespace OrderPresentationApi.Controllers
{
    [ApiController]
    [Route("api/materiais")]
    public class MaterialController : ControllerBase {

        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService) {
            _materialService = materialService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMateriais() {
            var materiais = await _materialService.GetAllAsync();
            return Ok(materiais);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMaterialById(int id) {
            var material = await _materialService.GetByIdAsync(id);

            if (material is null)
                return NotFound();

            return Ok(material);
        }

        [HttpPost]
        public async Task<IActionResult> PostMaterial(MaterialViewModel material) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var novoMaterial = await _materialService.CreateAsync(material);

            if (novoMaterial is null)
                return BadRequest("Esse ID de TipoMaterial não é válido.");

            return CreatedAtAction(nameof(GetMaterialById), new { id = novoMaterial.Id }, novoMaterial);

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMaterial(int id, MaterialViewModel material) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _materialService.UpdateAsync(id, material);

            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMaterial (int id) {
            return await _materialService.DeleteAsync(id) ? NoContent() : NotFound();
        }



        [HttpGet("tipos")]
        public async Task<IActionResult> GetAllTipos () {
            var tiposMaterial = await _materialService.GetTiposAsync();
            return Ok(tiposMaterial);
        }

        [HttpGet("tipos/{id:int}")]
        public async Task<IActionResult> GetTipoById (int id) {
            var tipo = await _materialService.GetTipoByIdAsync(id);

            if (tipo is null)
                return NotFound();

            return Ok(tipo);
        }

        [HttpPost("tipos")]
        public async Task<IActionResult> PostTipoMaterial (TipoMaterialViewModel tipoMaterial) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tipoAdicionado = await _materialService.CreateTipoAsync(tipoMaterial);

            return CreatedAtAction(nameof(GetTipoById), new { id = tipoAdicionado.Id }, tipoAdicionado);
        }

        [HttpPut("tipos/{id:int}")]
        public async Task<IActionResult> UpdateTipoMaterial (int id, TipoMaterialViewModel tipoMaterial) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _materialService.UpdateTipoAsync(id, tipoMaterial);

            return success ? NoContent() : NotFound();
        }

        [HttpDelete("tipos/{id:int}")]
        public async Task<IActionResult> DeleteTipoMaterial (int id) {
            return await _materialService.DeleteTipoAsync(id) ? NoContent() : NotFound();
        }
    }
}
