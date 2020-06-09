using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DirectorioV1.Api.Business.Models
{
    public class Ciudades
    {
        public int Id { get; set; }
        [DisplayName("Departamento")]
        public string DepartamentoId { get; set; }
        public IEnumerable<SelectListItem> DepartamentosList { get; set; }
        [DisplayName("Nombre de la ciudad")]
        [MaxLength(100, ErrorMessage = "El campo {0} solo puede contener hasta {1} caracteres.")]
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public bool Estado { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }
        [DisplayName("Código postal")]
        [MaxLength(10, ErrorMessage = "El campo {0} solo puede contener hasta {1} caracteres.")]
        public string Codigo_Postal { get; set; }

        public Departamentos Departamento { get; set; }
        public ICollection<Barrios> Barrios { get; set; }
    }
}
