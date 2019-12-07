using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Contracts.Entities
{
    public class Municipios2CiudadesEntity
    {
        public int Muncipio_Id { get; set; }
        public int Ciudad_Id { get; set; }

        public virtual MunicipiosEntity Municipios { get; set; }
        public virtual CiudadesEntity Ciudades { get; set; }


    }
}
