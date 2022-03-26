using System.ComponentModel.DataAnnotations;

namespace Proyectoagua.Models
{
    public class Blogs
    {
        [Key]
        public int Id_Blog { get; set; }
        public string UrlFoto { get; set; }
        public double Uso_Agua { get; set; }
        public string Ubicacion { get; set; }
        public string Opinion { get; set; }
        public int Id_usuario { get; set; }
        public int Id_Medidor_fk { get; set; }
     
        public virtual Medidores Medidores { get; set; }
        public virtual Usuario Usuarios { get; set; }
        


    }
}