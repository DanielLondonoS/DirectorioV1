using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DirectorioV1.Api.Business.Models
{
    public class Barrios
    {
        public int Id { get; set; }
        [Display(Name = "Ciudad")]
        public string CiudadId { get; set; }
        public IEnumerable<SelectListItem> CiudadesList { get; set; }
        [DisplayName("Nombre del barrio")]
        [MaxLength(100, ErrorMessage = "El campo {0} solo puede contener hasta {1} caracteres.")]
        public string Descripcion { get; set; }
        [DisplayName("Código Barrio")]
        [MaxLength(10, ErrorMessage = "El campo {0} solo puede contener hasta {1} caracteres.")]
        public string Codigo { get; set; }
        public bool Estado { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }
        [DisplayName("Código Postal")]
        [MaxLength(10, ErrorMessage = "El campo {0} solo puede contener hasta {1} caracteres.")]
        public string Codigo_Postal { get; set; }

        public Ciudades Ciudad { get; set; }
    }
}
