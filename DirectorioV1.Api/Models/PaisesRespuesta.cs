using DirectorioV1.Api.Business.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Models
{
    public class PaisesRespuesta : RespuestaBaseApi
    {
        [JsonProperty("pais", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Paises Pais { get; set; }
        [JsonProperty("listadoDePaises", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<Paises> ListadoDePaises { get; set; }
    }
}
