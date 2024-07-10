using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Services;

namespace MyApp.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase{
        private readonly VendaService _vendaService;
        public VendaController(VendaService vendaService){
            _vendaService = vendaService;
        }
        [HttpGet]
        public ActionResult<List<Venda>> GetAll() => _vendaService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Venda> Get(int id){
            var venda = _vendaService.Get(id);
            if(venda == null){
                return NotFound();
            }
            return venda;
        }
        [HttpPost]
        public IActionResult Create(Venda venda){
            _vendaService.Create(venda);
            return CreatedAtAction(nameof(Get), new{id = venda.Id}, venda);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Venda venda){
            var = existingVenda = _vendaService.Get(id);
            if(existingVenda == null){
                return NotFoun();
            }
            _vendaService.Update(id, venda);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var venda = _vendaService.Get(id)
            if(venda == null){
                return NotFound();
            }
            _vendaService.Delete(id);
            return NoContent();
        }
    }
}