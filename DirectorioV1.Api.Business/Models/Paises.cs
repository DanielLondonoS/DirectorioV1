﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.Business.Models
{
    public class Paises
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public bool Estado { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }
        public string Codigo_Postal { get; set; }
    }
}
