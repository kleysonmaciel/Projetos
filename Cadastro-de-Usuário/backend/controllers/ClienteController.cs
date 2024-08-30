using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClienteApi.Models;
using ClienteApi.Services;

namespace ClienteApi.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase{
        private readonly IClienteService _clienteService;
        public ClienteController(ClienteService clienteService) {
            _clienteService = clienteService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes() {
            var clientes = await _clienteService.GetAllClientesAsync();
            return Ok(clientes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteApi>> GetCliente(int id) {
            var clientes = await _clienteService.GetClienteByIdAsync(id);
            if(clientes == null) {
                return NotFound();
            }
            return Ok(clientes);
        }
        [HttpPost]
        public async Task<ActionResult<ClienteApi>> PostCliente(Cliente cliente){
            await _clienteService.AddClienteAsync(cliente);
            return CreatedAtAction("GetCliente", new { id = cliente.id }, cliente);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteApi cliente){
            if(id != cliente.id){
                return BadRequest();
            }
            await _clienteService.UpdateClienteAsync(cliente);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id){
            await _clienteService.DeleteClienteAsync(id);
            return NoContent();
        }
    }
}