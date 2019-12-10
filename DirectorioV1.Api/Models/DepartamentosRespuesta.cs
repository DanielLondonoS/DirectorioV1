using DirectorioV1.Api.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Models
{
    public class DepartamentosRespuesta : RespuestaBaseApi
    {
        public Departamentos Departamento { get; set; }
        public List<Departamentos> ListadoDeDepartamentos { get; set; }
    }
}
