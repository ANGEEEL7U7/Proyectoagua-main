using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Proyectoagua.Models
{
    public class BlogEmpresa
    {
        [Key]
        public int Id_BlogEmpresa { get; set; }
        public string UrlFoto_E { get; set; }
        public double Uso_Agua_E { get; set; }
        public string Ubicacion_E { get; set; }
        public string Opinion_E { get; set; }
        public int Id_empresa { get; set; }
        public int Id_Medidor_fk_E { get; set; }

    }
}