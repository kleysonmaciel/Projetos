using Microsoft.AspNetCore.Mvc;
using ProdutoWeb.Models;
using ProdutoWeb.Services;

namespace MyApp.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase{
        private readonly ProdutoService _produtoService
        public ProdutoController(ProdutoService produtoService){
            _produtoService = produtoService;
        }    
        [HttpGet]
        public ActionResult<List<Produto>> GetAll() => _produtoService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Produto> Get(int id){
            var produto = _produtoService.Get(id);
            if (produto == null){
                return NotFound();
            }
            return produto;
        }
        [HttpPost]
        public IActionResult Create(Produto produto){
            _produtoService.Create(produto);
            return CreatedAtAction(nameof(Get), new {id = produto.Id}, produto);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Produto produto){
            var existingProduto = _produtoService.Get(id);
            if(existingProduto == null){
                return NotFound();
            }
            _produtoService.Update(id, produto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var produto = _produtoService.Get(id);
            if(produto == null){
                return NotFound();
            }
            _produtoService.Delete(id);
            return NoContent();
        }
    }
}