using DirectorioV1.Api.Business.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Models
{
    public class CiudadesRespuesta : RespuestaBaseApi
    {
        [JsonProperty("ciudad", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Ciudades Ciudad { get; set; }
        [JsonProperty("listadoDeCiudades", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<Ciudades> ListadoDeCiudades { get; set; }
    }
}
