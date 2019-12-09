using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.Business.Models
{
    public class ClientesDirecciones
    {
        public int Id { get; set; }
        //public int Cliente_Id { get; set; }
        public string Direccion_Tipo_A { get; set; }
        public string Direccion_A { get; set; }
        public string Direccion_Tipo_B { get; set; }
        public string Direccion_B { get; set; }
        public string Direccion_Observacion { get; set; }
        public string Direccion_Compuesta { get; set; }
        public int Pais_Id { get; set; }
        public int Departamento_Id { get; set; }
        public int Ciudad_Id { get; set; }
        public int Municipio_Id { get; set; }
        public int Barrio_Id { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Telefono { get; set; }
        public bool Servicio_Domicilio { get; set; }
        public bool Estado { get; set; }
    }
}
