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
    }
}
