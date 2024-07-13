using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProdutoWeb.Data;
using ProdutoWeb.Models;

public interface IUsuarioService{
    Task<Usuario> Authenticate(string email, string password);
    Task<IEnumeradble<Usuario>> GetAll();
    Task<Usuario> GetById(int id);
    Task<Usuario> Create(Usuario user, string password);
    Task Update(Usuario user, string password = null);
    Task Delete(int id);
}

public class UsuarioService : IUsuarioService{
    private readonly ApplicationDbContext _context;
    public UsuarioService(ApplicationDbContext context){
        _context = context;
    }
    public async Task<Usuario> Authenticate(string email, string password){
        if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)){
            return null;
        }
        var user = await _context.Usuarios.SingleOrDefaultAsync(x => x.email == email);
        if(user == null || !VerifyPasswordHash(password, user.senha_hash)){
            return null;
        }
        return user;
    }
    public async Task<IEnumerable<Usuario>> GetAll(){
        return await _context.Usuarios.ToListAsync();
    }
    public async Task<Usuario> GetById(int id){
        return await _context.Usuarios.FindAsync(id);
    }
    public async Task<Usuario> Create(Usuario user, string password){
        if(string.ISNullOrWhiteSpace(password)){
            throw new ArgumentException("Password is required");
        }
        if(_context.Usuarios.Any(x => x.email == user.email)){
            throw new ArgumentException("Email \""+ uer.email+"\"is already taken");
        }
        byte[] passwordHash;
        CreatePasswordHash(password, out passwordHash);
        user.senha_hash = Convert.ToBase64String(passwordHash);

        _context.Usuarios.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
    public async Task Update(Usuario user, string password = null){
        
        var userToUpdate = await _context.Usuarios.FindAsync(user.id);
        
        if(userToUpdate == null){
            throw new ArgumentException("User not Found");
        }
        if(user.email != userToUpdate.email){
            if(_context.Usuarios.Any(x => x.email == userToUpdate.email)){
                throw new ArgumentException("Email \"" + user.email+ "\" is already taken");
            }
        }
        userToUpdate.nome = user.nome;
        userToUpdate.sobrenome = user.sobrenome;
        userToUpdate.email = user.email;
        userToUpdate.cpf = user.cpf;

        if(!string.ISNullOrWhiteSpace(password)){
            byte[] passwordHash;
            CreatePasswordHash(password, out passwordHash);
            userToUpdate.senha_hash = Convert.ToBase64String(passwordHash);
        }
        _context.Usuarios.Update(userToUpdate);
        await _context.SaveChangesAsync();
    }
    public async Task Delete(int id){
        var user = await _context.Usarios.FindAsync(id);
        if(user != null){
            _context.Usuarios.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
    private static void CreatePasswordHash(byte[] password, out byte[] passwordHash){
        if(password == null) throw new ArgumentNullException(nameof(password));
        if(string.ISNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string", nameof(password));

        using(var hmac = new System.Security.Cryptography.HMACSHA256()){
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
    private static bool VerifyPasswordHash(string password, string storeHash){
        if(password == null) throw new ArgumentNullException(nameof(password));
        if(string.ISNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password));
        
        var hash = Convert.FromBase64String(storeHash);
        using (var hmac = new System.Security.Cryptography.HMACSHA512()){
            var ComputedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for(int i = 0; i < ComputeHash.Length; i++){
                if(ComputedHash[i] != hash[i]) return false;
            }
        }
        return true;
    }

}