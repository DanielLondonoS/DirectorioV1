using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Contracts.Entities
{
    public class Barrios2MunicipiosEntity
    {
        public int Barrio_Id { get; set; }
        public int Municipio_Id { get; set; }

        public virtual BarriosEntity Barrios { get; set; }
        public virtual MunicipiosEntity Municipios { get; set; }


    }
}
