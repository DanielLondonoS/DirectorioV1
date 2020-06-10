﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Contracts.Entities
{
    public class BarriosEntity : IEntity
    {
        public int Id { get; set; }        
        [MaxLength(100)]
        public string Descripcion { get; set; }
        [MaxLength(10)]
        public string Codigo { get; set; }
        public bool Estado { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }
        [MaxLength(10)]
        public string Codigo_Postal { get; set; }
        public int CiudadId { get; set; }        
        public CiudadesEntity Ciudad { get; set; }

    }
}
