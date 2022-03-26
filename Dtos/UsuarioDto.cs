using System.Globalization;
using System.Runtime.Serialization;
using System;

namespace Proyectoagua.Dtos
{
    public class UsuarioDto
    {
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }
        public string domicilio { get; set; }
        public DateTime Nacimiento{ get; set; }
        public int Id_Medidor { get; set; }
        public string Correo { get; set; }

        
    }
}