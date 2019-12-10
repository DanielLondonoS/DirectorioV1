using DirectorioV1.Api.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Models
{
    public class CiudadesRespuesta : RespuestaBaseApi
    {
        public Ciudades Ciudad { get; set; }
        public List<Ciudades> ListadoDeCiudades { get; set; }
    }
}
