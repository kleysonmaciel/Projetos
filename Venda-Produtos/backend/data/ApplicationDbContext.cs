using Microsoft.EntityFrameworkCore;
using ProdutoWeb.Models;

namespace ProdutoWeb.Data{
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOption<ApplicationDbContext > options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venda> Vendas { get; set; }
    }
}