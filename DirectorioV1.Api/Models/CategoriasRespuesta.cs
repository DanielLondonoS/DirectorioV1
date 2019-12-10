using DirectorioV1.Api.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Models
{
    public class CategoriasRespuesta : RespuestaBaseApi
    {
        public Categorias Categoria { get; set; }
        public List<Categorias> ListadoDeCategorias { get; set; }
    }
}
