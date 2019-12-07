using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Contracts.Entities
{
    public class DepartamentosEntity
    {
        public int Id { get; set; }
        public int Paid_Id { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public bool Estado { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }
        public string Codigo_Postal { get; set; }

        public virtual PaisesEntity Paises { get; set; }
        public virtual CiudadesEntity Ciudades { get; set; }
        public virtual ClientesDireccionesEntity ClientesDirecciones { get; set; }


        public virtual ICollection<Paises2DepartamentosEntity> Paises2Departamentos { get; set; }
        public virtual ICollection<Ciudades2DepartamentosEntity> Ciudades2Departamentos { get; set; }


    }
}
