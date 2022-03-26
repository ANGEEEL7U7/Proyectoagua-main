using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyectoagua.Data.Interface;
using Proyectoagua.Models;
using System.Linq;

namespace Proyectoagua.Data
{
    public class ApiRepository : IApiRespository
    {
        private readonly AppDbContext _context;
        public ApiRepository(AppDbContext context)
        {
        
        _context = context;
        }
        public void Add<P>(P entity) where P : class
        {
            _context.Add(entity);
        }

        public void Delete<P>(P entity) where P : class
        {
            _context.Remove(entity);
        }

        public async Task<BlogEmpresa> GetBlogEmpresaIdAsync(int Id_BlogEmpresa)
        {
            var BlogEmpresa = await _context.BlogEmpresas.FirstOrDefaultAsync(x => x.Id_BlogEmpresa == Id_BlogEmpresa);
            return BlogEmpresa;
        }

        public async Task<IEnumerable<BlogEmpresa>> GetBlogEmpresasAsync()
        {
            var BlogEmpresa = await _context.BlogEmpresas.ToListAsync();
            return BlogEmpresa;
        }

        public async  Task<IEnumerable<Blogs>> GetBlogsAsync()
        {
            var Blog = await _context.Blogs.ToListAsync();
            return Blog;
        }

        public async Task<Blogs> GetBlogsIdAsync(int Id_Blog)
        {
            var Blog = await _context.Blogs.FirstOrDefaultAsync(x => x.Id_Blog == Id_Blog);
            return Blog;
        }

        public async Task<Empresas> GetEmpresaIdAsync(int Id_Empresa)
        {
            var Empresas = await _context.Empresas.FirstOrDefaultAsync(x => x.Id_Empresa == Id_Empresa);
            return Empresas;
        }

        public async Task<IEnumerable<Empresas>> GetEmpresasAsync()
        {
            var Empresas = await _context.Empresas.ToListAsync();
            return Empresas;
        }

        public async Task<IEnumerable<Medidores>> GetMedidoresAsync()
        {
            var Medidor = await _context.Medidores.ToListAsync();
            return Medidor;
        }

        public async Task<Medidores> GetMedidoresByIdAsync(int Id_Medidor)
        {
            var Medidores = await _context.Medidores.FirstOrDefaultAsync(x => x.Id_Medidor == Id_Medidor);
            return Medidores;
        }

        public async Task<Medidores> GetMedidoresByNombreAsync(string Marca)
        {
            var Medidores = await _context.Medidores.FirstOrDefaultAsync(x => x.Marca == Marca);
            return Medidores;
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int Id)
        {
            var Usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id_us == Id);
            return Usuario;
        }

        public async Task<Usuario> GetUsuariologin(string Nombre, string Contrasenia)
        {
            var Usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Nombre == Nombre && x.Contrasenia == Contrasenia);
            return Usuario;
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosAsync()
        {
            var Usuario = await _context.Usuarios.ToListAsync();
            return Usuario;
        }

        public Task<List<Usuario>> ObtenerUsuarioPorGenero(int Medidores)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        
    }
}