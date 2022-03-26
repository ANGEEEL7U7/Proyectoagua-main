using Microsoft.EntityFrameworkCore;
using Proyectoagua.Models;

namespace Proyectoagua.Data.Interface
{
    public class AppDbContext : DbContext{

        public DbSet<Medidores> Medidores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<BlogEmpresa> BlogEmpresas { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
       
    }
}