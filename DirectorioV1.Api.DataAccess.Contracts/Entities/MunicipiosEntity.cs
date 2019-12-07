using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Contracts.Entities
{
    public class MunicipiosEntity
    {
        public int Id { get; set; }
        //public int Ciudad_Id { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public bool Estado { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }
        public string Codigo_Postal { get; set; }

        public virtual CiudadesEntity Ciudades { get; set; }
        //public virtual BarriosEntity Barrios { get; set; }
        //public virtual ClientesDireccionesEntity ClientesDirecciones { get; set; }

        public virtual ICollection<Municipios2CiudadesEntity> Municipios2Ciudades { get; set; }
        public virtual ICollection<Barrios2MunicipiosEntity> Barrios2Municipios { get; set; }



    }
}
