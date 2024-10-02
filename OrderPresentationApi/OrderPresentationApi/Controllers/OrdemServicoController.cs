using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderPresentationApi.Services;
using OrderPresentationApi.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace OrderPresentationApi.Controllers {

    [ApiController]
    [Route("api/ordens-servico")]
    public class OrdemServicoController : ControllerBase {

        private readonly IOrdemServicoService _ordemServicoService;

        public OrdemServicoController (IOrdemServicoService ordemServicoService) {
            _ordemServicoService = ordemServicoService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll () {
            var ordensServico = _ordemServicoService.GetAll();
            return Ok(ordensServico);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById (int id) {
            var ordemServicoEncontrada = await _ordemServicoService.GetById(id);

            if (ordemServicoEncontrada is null)
                return NotFound();

            return Ok(ordemServicoEncontrada);
        }


        [HttpPost]
        public async Task<IActionResult> Post (OrdemServicoViewModel ordemServico) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ordemServicoCriada = await _ordemServicoService.CreateOrdemServico(ordemServico);

            return CreatedAtAction(nameof(GetById), new { ordemServicoCriada.Id }, ordemServicoCriada);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update (int id, OrdemServicoViewModel ordemServico) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _ordemServicoService.UpdateOrdemServico(id, ordemServico);

            return success ? NoContent() : NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id) {
            return await _ordemServicoService.DeleteOrdemServico(id) ? NoContent() : NotFound();
        }
    } 
}
