using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProdutoWeb.Data;
using ProdutoWeb.Models;

public interface IVendaService{
    Task<IEnumerable<Venda>> GetAll();
    Task<venda> GetById(int id);
    Task Create(Venda venda);
    Task Update(Venda venda);
    Task Delete(int id);
}
public class VendaService : IVendaService{
    private readonly ApplicationDbContext _context;

    public VendaService(ApplicationDbContext context){
        _context = context;
    }
    public async Task<IEnumerable<Venda>> GetAll(){
        return await _context.Venda.ToListAsync();
    }
    public async Task<Venda> GetById(int id){
        return await _context.Vendas.FindAsync(id);
    }
    public async Task Create(Venda venda){
        _context.Vendas.Add(venda);
        await _context.SaveChangesAsync();
    }
    public async Task Update(Venda venda){
        var existingVenda = await _context.Vendas.FindAsync(venda.id);
        if(existingVenda == null){
            throw new ArgumentException("Venda not found");
        }
        existingVenda.usuario_id = venda.usuario_id;
        existingVenda.produto_id = venda.produto_id;
        existingVenda.quantidade = venda.quantidade;

        _context.Vendas.Update(existingVenda);
        await _context.SaveChangesAsync();
    }
    public async Task Delete(int id){
        var venda = await _context.Vendas.FindAsync(id);
        if(venda != null){
            _context.Vendas.Remove(venda);
            await _context.SaveChangesAsync();
        }
    }

}