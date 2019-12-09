using DirectorioV1.Api.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Models
{
    public class BarriosRespuesta : RespuestaBaseApi
    {
        public Barrios Barrio { get; set; }
        public List<Barrios> ListadoDeBarrios { get; set; }
    }
}
