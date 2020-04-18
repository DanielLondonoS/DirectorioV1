using DirectorioV1.Api.Business.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Models
{
    public class CategoriasRespuesta : RespuestaBaseApi
    {
        [JsonProperty("categoria", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Categorias Categoria { get; set; }
        [JsonProperty("listadoDeCategorias", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<Categorias> ListadoDeCategorias { get; set; }
    }
}
