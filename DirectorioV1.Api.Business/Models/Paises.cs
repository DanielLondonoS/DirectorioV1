using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DirectorioV1.Api.Business.Models
{
    public class Paises
    {
        public int Id { get; set; }
        [DisplayName("Nombre del país")]
        [MaxLength(100, ErrorMessage = "El campo {0} solo puede contener hasta {1} caracteres.")]
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public bool Estado { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }
        [DisplayName("Código postal")]
        [MaxLength(10, ErrorMessage = "El campo {0} solo puede contener hasta {1} caracteres.")]
        public string Codigo_Postal { get; set; }
        public ICollection<Departamentos> Departamentos { get; set; }
    }
}
