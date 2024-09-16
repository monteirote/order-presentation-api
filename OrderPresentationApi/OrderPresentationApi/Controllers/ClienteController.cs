using Microsoft.AspNetCore.Mvc;
using OrderPresentationApi.Services;
using OrderPresentationApi.ViewModels;
using System.Threading.Tasks;

namespace OrderPresentationApi.Controllers
{

    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase {

        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService) {
            _clienteService = clienteService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var clienteEncontrado = await _clienteService.GetById(id);

            if (clienteEncontrado == null) 
                return NotFound();
            
            return Ok(clienteEncontrado);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var clientes = await _clienteService.GetAll();
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> PostCliente (ClienteViewModel novoCliente) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cliente = await _clienteService.CreateCliente(novoCliente);

            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente (int id, ClienteViewModel novoCliente) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _clienteService.UpdateCliente(id, novoCliente);

            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente (int id) {
            return await _clienteService.DeleteCliente(id) ? NoContent() : NotFound();
        }
    }
}
