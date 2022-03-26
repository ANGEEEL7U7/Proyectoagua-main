using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Proyectoagua.Models
{
    public class Empresas
    {
        [Key]
        public int Id_Empresa { get; set; }
        public int Rfc { get; set; }
        public string Nombre_E { get; set; }
        public string Contasenia_E { get; set; }
        public string Ubicacion_E { get; set; }
        public DateTime Fecha_Regristro { get; set; }
        public int Id_Medidor_E { get; set; }
        public string Correo_E { get; set; }
        public virtual Medidores Medidores { get; set; }
        public virtual List<BlogEmpresa> BlogEmpresas { get; set; }

    }
}