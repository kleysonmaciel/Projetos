using Microsoft.AspNetCore.Mvc;
using ProdutoWeb.Models;
using ProdutoWeb.Services;

namespace MyApp.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase{
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService){
            _usuarioService = usuarioService;
        }
        [HttpGet]
        public ActionResult<List<Usuario>> GetAll() => _usuarioService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id){
            var Usuario = _usuarioService.Get(id);
            if(Usuario == null){
                return NotFound();
            }
            return (Usuario);
        }
        [HttpPost]
        public IActionResult Create(Usuario usuario){
            _usuarioService.Create(usuario);
            return CreatedAtAction(nameof(Get), new {id = usuario.Id}, usuario);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Usuario usuario){
            var existingUsuario = _usuarioService.Get(id);
            if(existingUsuario == null){
                return NotFound();
            }
            _usuarioService.Update(id, usuario);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var usuario = _usuarioService.Get(id);
            if(usuario == null){
                return NotFound();
            }
            _usuarioService.Delete(id);
            return NoContent();
        }
    }
}