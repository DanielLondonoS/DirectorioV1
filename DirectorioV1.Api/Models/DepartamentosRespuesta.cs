using DirectorioV1.Api.Business.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Models
{
    public class DepartamentosRespuesta : RespuestaBaseApi
    {
        [JsonProperty("departamento", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Departamentos Departamento { get; set; }
        [JsonProperty("listadoDeDepartamentos", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<Departamentos> ListadoDeDepartamentos { get; set; }
    }
}
