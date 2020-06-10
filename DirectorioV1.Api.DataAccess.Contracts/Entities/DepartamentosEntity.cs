using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Contracts.Entities
{
    public class DepartamentosEntity : IEntity
    {
        public int Id { get; set; }                
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public bool Estado { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }
        public string Codigo_Postal { get; set; }

        public ICollection<CiudadesEntity> Ciudades { get; set; }

        public int PaisId { get; set; }
        public PaisesEntity Pais { get; set; }
    }
}
