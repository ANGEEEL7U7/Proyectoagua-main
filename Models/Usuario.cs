using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyectoagua.Models
{
    public class Usuario
    {
        [Key]
        public int Id_us { get; set; }
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }
        public string domicilio { get; set; }
        public DateTime Nacimiento{ get; set; }
        public int Id_Medidor { get; set; }
        public string Correo { get; set; }
        public virtual Medidores Medidores { get; set; }

         public virtual List<Blogs> Blogs { get; set; }
        

    }
}