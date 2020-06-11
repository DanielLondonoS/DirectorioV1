using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DirectorioV1.Api.Business.Models
{
    public class ClientesDirecciones
    {
        public ClientesDirecciones()
        {
            this.Cliente = new Clientes();
            this.Pais = new Paises();
            this.Ciudad = new Ciudades();
            this.Departamento = new Departamentos();
        }
        public int Id { get; set; }
        [DisplayName("Cliente")]
        public int ClienteId { get; set; }
        public IEnumerable<SelectListItem> ClientesList { get; set; }
        [DisplayName("Seleccione tipo(ej: calle,carrera...)")]
        public string Direccion_Tipo_A { get; set; }
        public IEnumerable<SelectListItem> DireccionTiposAList { get; set; }
        [DisplayName("Dato")]
        public string Direccion_A { get; set; }
        [DisplayName("Seleccione tipo(ej: calle,carrera...)")]
        public string Direccion_Tipo_B { get; set; }
        //public IEnumerable<SelectListItem> DireccionTiposBList { get; set; }
        [DisplayName("Dato")]
        public string Direccion_B { get; set; }
        [DisplayName("Observaciones de la dirección")]
        [MaxLength(250, ErrorMessage = "El campo {0} solo puede contener hasta {1} caracteres.")]
        public string Direccion_Observacion { get; set; }
        [DisplayName("Dirección")]
        [MaxLength(400, ErrorMessage = "El campo {0} solo puede contener hasta {1} caracteres.")]
        public string Direccion_Compuesta { get; set; }
        [DisplayName("Pais")]
        public int PaisId { get; set; }
        public IEnumerable<SelectListItem> PaisesList { get; set; }
        [DisplayName("Departamento")]
        public int DepartamentoId { get; set; }
        public IEnumerable<SelectListItem> DepartamentosList { get; set; }
        [DisplayName("Ciudad")]
        public int CiudadId { get; set; }
        public IEnumerable<SelectListItem> CiudadesList { get; set; }
        [DisplayName("Barrio")]
        public int BarrioId { get; set; }
        public IEnumerable<SelectListItem> BarriosList { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Telefono { get; set; }
        [DisplayName("¿Tiene servicio domicilio?")]
        public bool Servicio_Domicilio { get; set; }
        public bool Estado { get; set; }

        public Clientes Cliente { get; set; } 
        public Paises Pais { get; set; } 
        public Ciudades Ciudad { get; set; } 
        public Departamentos Departamento { get; set; }
        public Barrios Barrio { get; set; }
    }
}
