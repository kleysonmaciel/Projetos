using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProdutoWeb.Models;
using ProdutoWeb.Services;

namespace ProdutoWeb.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase{
        private readonly IVendaService _vendaService;
        public VendaController(IVendaService vendaService){
            _vendaService = vendaService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var vendas = await _vendaService.GetAll();
            return Ok(vendas);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){
            var venda = await _vendaService.GetById()
            return Ok(venda);
        }
        [HttpPost]
        public async Tassk<IActionResult> Create([FromBody] Venda venda){
            try{
                await _vendaService.Create(venda);
                return Ok(venda);
            }
            catch(Exception ex){
                return BadRequest(new {message = ex.Message});
            }
        }
        [Http("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Venda venda){

            venda.id = id;
            
            try{
                await _vendaService.Update(venda);
                return Ok;
            }
            catch (Exception ex){
                return BadRequest(new {message = ex.Message});
            }
        }
        [HttpDelete("{id}")]
        publiuc async async Task<IActionResult> Delete(int id){
            await _vendaService.Delete(id);
            return Ok();
        }
    }
}