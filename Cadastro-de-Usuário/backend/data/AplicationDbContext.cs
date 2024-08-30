using Microsoft.EntityFrameworkCore;
using ClienteApi.Models;

namespace ClienteApi.Data{
    public class ApplicationDbContext : DbContext{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options){

        }
        public DbSet<ClienteApi> Clientes{ get; set; }
    }
}