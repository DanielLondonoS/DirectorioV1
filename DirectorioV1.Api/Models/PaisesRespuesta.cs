using DirectorioV1.Api.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Models
{
    public class PaisesRespuesta : RespuestaBaseApi
    {
        public Paises Pais { get; set; }
        public List<Paises> ListadoDePaises { get; set; }
    }
}
