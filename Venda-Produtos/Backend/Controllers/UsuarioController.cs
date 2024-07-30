using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProdutoWeb.Models;
using ProdutoWeb.Services;

namespace ProdutoWeb.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase{
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService){
            _usuarioService = usuarioService;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel model){
            var user = await _usuarioService.Authenticate(model.Username, model.Password);
            if (user == null){
                return BadRquest(new {message = "Email ou a senha estão incorretos"});
            }
            
            return Ok(user);
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var users = await _usuarioService.GetAll();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){
            var users = await _usuarioService.GetById(id);
            return Ok(users);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateModel model){
            var user = new usuario{
                nome = model.nome,
                sobrenome = model.sobrenome,
                email = model.email,
                cpf = model.cpf
            };
            try{
                await _usuarioService.Create(user, model.Password);
                return Ok(user);
            }
            catch(Exception ex){
                return BadRquest(new{message = ex.Message});
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateModel model){
            var user = new UsuarioController{
                id = id,
                nome = model.nome,
                sobrenome = model.sobrenome,
                email = model.email,
                cpf = model.cpf
            };
            try{
                await _usuarioService.Update(user, model.Password);
                return Ok();
            }
            catch (Exception ex){
                return BadRquest(new{message = ex.Message});
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            await _usuarioService.Delete(id);
            return Ok();
        }
    }
    public class AuthenticateModel{
        public string email { get; set; }
        public string password { get; set; }
    }
    public class CreateModel{
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string email { get; set; }
        public string cpf { get; set; }
        public string password {get; set; }
    }
    public class UpdateModel{
        public string nome { get; set;}
        public string sobrenome { get; set;}
        public string email { get; set; }
        public string cpf { get; set; }
        public string password{get; set;}
    }
}