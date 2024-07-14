using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProdutoWeb.Data;
using ProdutoWeb.Models;

public interface IProdutoService{
    Task<IEnumerable<Produto>> GetAll();
    Task<Produto> GetById(int id);
    Task Create(Produto produto);
    Task Upadate(Produto produto);
    Task Delete(int id);
}

public class ProdutoService : IProdutoService {
    private readonly ApplicationDbContext _dbContext;
    public ProdutoService(ApplicationDbContext context) {
        _dbContext = context;
    }
    public async Task<IEnumerable<Produto>> GetAll() {
        return await _dbContext.Produtos.ToListAsync();
    }
    public async Task<Produto> GetById(int id){
        return await _context.Produtos.FindAsync(id);
    }
    public async Task Create(Produto produto) {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
    }
    public async Task Update(Produto produto) {
        var existingProduto = await _context.Produtos.FindAsync(produto.id);
        if(existingProduto == null){
            throw new ArgumentException("Produto not found");
        }
        existingProduto.nome = produto.nome;
        existingProduto.preco = produto.preco;
        existingProduto.quantidade_estoque = produto.quantidade_estoque;
        existingProduto.imagem_url = produto.imagem_url;

        _context.Produtos.Update(existingProduto);
        await _context.SaveChangesAsync();
    }
    public async Task Delete(int id){
        var produto = await _context.Produtos.FindAsync(id);
        if(produto != null){
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync() ;
        }
    }
}