using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyectoagua.Models
{
    public class Medidores
    {
        [Key]
        public int Id_Medidor { get; set; }
        public string Marca { get; set; }
        public string Proveedor { get; set; }

        public virtual List<Usuario> Usuarios { get; set; }

        public virtual List<Blogs> Blogs { get; set; }
        public virtual List<Empresas> Empresas { get; set; }
    }
}