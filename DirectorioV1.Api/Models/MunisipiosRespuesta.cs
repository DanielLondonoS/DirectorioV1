using DirectorioV1.Api.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Models
{
    public class MunisipiosRespuesta : RespuestaBaseApi
    {
        public Municipios Municipio { get; set; }
        public List<Municipios> ListadoDeMunicipios { get; set; }
    }
}
