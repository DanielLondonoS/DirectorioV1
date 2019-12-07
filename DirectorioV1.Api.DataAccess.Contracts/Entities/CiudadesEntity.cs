﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Contracts.Entities
{
    public class CiudadesEntity
    {
        public int Id { get; set; }
        //public int Departamento_Id { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public bool Estado { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }
        public string Codigo_Postal { get; set; }

        public virtual DepartamentosEntity Departamentos { get; set; }
        //public virtual MunicipiosEntity Municipios { get; set; }
        //public virtual ClientesDireccionesEntity ClientesDirecciones { get; set; }


        public virtual ICollection<Ciudades2DepartamentosEntity> Ciudades2Departamentos { get; set; }
        public virtual ICollection<Municipios2CiudadesEntity> Municipios2Ciudades { get; set; }


    }
}
