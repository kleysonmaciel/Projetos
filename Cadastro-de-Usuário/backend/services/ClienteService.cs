using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClienteApi.Data;
using ClienteApi.Models;

namespace ClienteApi.Services{
    public class ClienteService{
        private readonly ApplicationDbContext _context;
        public ClienteService(ApplicationDbContext context){
            _context = context;
        }
        public async Task<List<Cliente>> GetAllClientesAsync(){
            return await _context.Clientes.ToListAsync();
        }
        public async Task<Cliente> GetClienteByIdAsync(int id){
            return await _context.Clientes.FindAsync(id);
        }
        public async Task AddClienteAsync(ClienteApi cliente){
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateClienteAsync(Cliente cliente){
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteClienteAsync(int id){
            var cliete = await _context.Clientes.FindAsync(id);
            if(cliete != null){
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}