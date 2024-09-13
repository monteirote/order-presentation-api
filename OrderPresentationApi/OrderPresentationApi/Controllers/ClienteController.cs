using Microsoft.AspNetCore.Mvc;
using OrderPresentationApi.Services;
using OrderPresentationApi.ViewModels;

namespace OrderPresentationApi.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("/{id}")]
        public IActionResult GetCliente(int id)
        {
            var cliente = _clienteService.GetCliente(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult PostCliente(CreateClienteViewModel cliente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _clienteService.CadastrarCliente(cliente);

                return Ok(cliente);
            } catch (Exception ex)
            {
                return StatusCode(500, "Aconteceu um erro ao processar essa requisição: " + ex.Message);
            }
        }
    }
}
