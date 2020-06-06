using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Contracts.Entities
{
    public class BarriosEntity : IEntity
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Ciudad")]
        public int CiudadId { get; set; }
        [DisplayName("Nombre del barrio")]
        [MaxLength(100, ErrorMessage = "El campo {0} solo puede contener hasta {1} caracteres.")]
        public string Descripcion { get; set; }
        [DisplayName("Código Barrio")]
        [MaxLength(10, ErrorMessage = "El campo {0} solo puede contener hasta {1} caracteres.")]
        public string Codigo { get; set; }
        public bool Estado { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }
        [DisplayName("Codigo postal")]
        [MaxLength(10, ErrorMessage = "El campo {0} solo puede contener hasta {1} caracteres.")]
        public string Codigo_Postal { get; set; }

        public CiudadesEntity Ciudad { get; set; }



    }
}
