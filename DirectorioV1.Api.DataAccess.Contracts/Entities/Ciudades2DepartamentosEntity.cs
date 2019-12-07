using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Contracts.Entities
{
    public class Ciudades2DepartamentosEntity
    {
        public int Ciudad_Id { get; set; }
        public int Departamento_Id { get; set; }

        public virtual CiudadesEntity Ciudades { get; set; }
        public virtual DepartamentosEntity Departamentos { get; set; }


    }
}
