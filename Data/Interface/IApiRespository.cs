using System.Collections.Generic;
using System.Threading.Tasks;
using Proyectoagua.Models;

namespace Proyectoagua.Data.Interface
{
    public interface IApiRespository
    {
        void Add<P>(P entity) where P : class;
        void Delete<P>(P entity) where P : class;

        Task<bool> SaveAll();
        Task<IEnumerable<Medidores>> GetMedidoresAsync();
        Task<Medidores> GetMedidoresByIdAsync(int Id_Medidor);
        Task<Medidores> GetMedidoresByNombreAsync(string Marca);
        Task<IEnumerable<Usuario>> GetUsuariosAsync();
        Task<IEnumerable<Empresas>> GetEmpresasAsync();
        Task<Usuario> GetUsuarioByIdAsync(int Id_us);
        Task<Usuario> GetUsuariologin(string Nombre, string Contrasenia);
        Task<Empresas> GetEmpresaIdAsync(int Id_Empresa);
        Task<List<Usuario>> ObtenerUsuarioPorGenero(int Id_Medidor);
        Task<IEnumerable<Blogs>> GetBlogsAsync();
        Task<IEnumerable<BlogEmpresa>> GetBlogEmpresasAsync();
        Task<Blogs> GetBlogsIdAsync(int Id_Blog);
        Task<BlogEmpresa> GetBlogEmpresaIdAsync(int Id_BlogEmpresa);


    }
}