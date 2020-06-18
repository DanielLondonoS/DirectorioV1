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
        public string Direccion_Tipo_A { get; set; }
        public string Direccion_A { get; set; }
        public string Direccion_Tipo_B { get; set; }
        public string Direccion_B { get; set; }
        [MaxLength(250)]
        public string Direccion_Observacion { get; set; }
        [MaxLength(400)]
        public string Direccion_Compuesta { get; set; }        
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Telefono { get; set; }
        public string Horario { get; set; }
        public bool Servicio_Domicilio { get; set; }
        public bool Estado { get; set; }

        public int ClienteId { get; set; }
        public ClientesEntity Cliente { get; set; }
        public int PaisId { get; set; }
        //public PaisesEntity Pais { get; set; }
        public int CiudadId { get; set; }
        //public CiudadesEntity Ciudad { get; set; }
        public int DepartamentoId { get; set; }
        //public DepartamentosEntity Departamento { get; set; }
        public int BarrioId { get; set; }
        //public BarriosEntity Barrio { get; set; }

    }
}
