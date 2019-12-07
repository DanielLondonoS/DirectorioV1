using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Contracts.Entities
{
    public class Paises2DepartamentosEntity
    {
        public int Pais_Id { get; set; }
        public int Departamento_Id { get; set; }

        public virtual PaisesEntity Paises { get; set; }
        public virtual DepartamentosEntity Departamentos { get; set; }

    }
}
