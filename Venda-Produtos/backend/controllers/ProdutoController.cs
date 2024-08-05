using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProdutoWeb.Models;
using ProdutoWeb.Services;
using MyApp.Controllers;

namespace MyApp.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase{
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService){
            _produtoService = produtoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var produtos = await _produtoService.GetAll();
            return Ok(produtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){
            var produto = await _produtoService.GetById(id);
            return Ok(produto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Produto produto){
            try{
                await _produtoService.Create(produto);
                return Ok(produto);
            }
            catch(Exception ex){
                return BadRequest(new { message = ex.Message});
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProdutoController produto){
            produto.Id = id;

            try{
                await _produtoService.Update(produto);
                return ok();
            }
            catch (Exception ex){
                return BadRequest(new{ message = ex.Message});
            }
        }
        [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id){
                await _produtoService.Delete(id);
                return Ok();
        }
    }
}