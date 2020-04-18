using DirectorioV1.Api.Business.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Models
{
    public class BarriosRespuesta : RespuestaBaseApi
    {
        [JsonProperty("barrio", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Barrios Barrio { get; set; }
        [JsonProperty("listadoDeBarrios", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<Barrios> ListadoDeBarrios { get; set; }
    }
}
