using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Contracts.Entities
{
    public class ClientesDireccionesEntity : IEntity
    {
        public int Id { get; set; }
        [DisplayName("Cliente")]
        public int ClienteId { get; set; }
        [DisplayName("Seleccione tipo")]
        public string Direccion_Tipo_A { get; set; }
        [DisplayName("Dato")]
        public string Direccion_A { get; set; }
        public string Direccion_Tipo_B { get; set; }
        public string Direccion_B { get; set; }
        [DisplayName("Observaciones de la dirección")]
        [MaxLength(250, ErrorMessage = "El campo {0} solo puede contener hasta {1} caracteres.")]
        public string Direccion_Observacion { get; set; }
        [DisplayName("Dirección")]
        [MaxLength(400, ErrorMessage = "El campo {0} solo puede contener hasta {1} caracteres.")]
        public string Direccion_Compuesta { get; set; }
        [DisplayName("Pais")]
        public int Pais_Id { get; set; }
        [DisplayName("Departamento")]
        public int Departamento_Id { get; set; }
        [DisplayName("Ciudad")]
        public int Ciudad_Id { get; set; }
        [DisplayName("Municipio")]
        public int Municipio_Id { get; set; }
        [DisplayName("Barrio")]
        public int Barrio_Id { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Telefono { get; set; }
        [DisplayName("¿Tiene servicio domicilio?")]
        public bool Servicio_Domicilio { get; set; }
        public bool Estado { get; set; }

        public ClientesEntity Cliente { get; set; }

    }
}
