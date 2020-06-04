using DirectorioV1.Api.Aplication.Contracts.Services;
using DirectorioV1.Api.Business.Models;
using DirectorioV1.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarriosController : ControllerBase
    {
        private readonly IBarriosServices _barriosServices;
        public BarriosController(IBarriosServices barriosServices)
        {
            _barriosServices = barriosServices;
        }

        [HttpPost]
        [Route("CrearBarrio")]
        public async Task<ActionResult<BarriosRespuesta>> AgregarBarrio([FromBody] Barrios barrio)
        {
            var barrioCreado = await _barriosServices.CrearNuevoBarrio(barrio);
            if (barrioCreado != null)
            {
                return new BarriosRespuesta()
                {
                    Barrio = barrioCreado,
                    EsExitoso = true,
                    Mensaje = "Barrio Creado Exitosamente",
                    ListadoDeBarrios = null

                };
            }

            return new BarriosRespuesta()
            {
                Barrio = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al crear el barrio",
                ListadoDeBarrios = null
            };

        }
        [HttpGet]
        [Route("ObtenerBarrios")]
        public ActionResult<BarriosRespuesta> ObtenerBarrios()
        {
            var listaDeBarrios = _barriosServices.ListadoDeBarrios();
            if (listaDeBarrios != null)
            {
                return new BarriosRespuesta()
                {
                    Barrio = null,
                    EsExitoso = true,
                    Mensaje = "Listado de Barrios",
                    ListadoDeBarrios = listaDeBarrios

                };
            }

            return new BarriosRespuesta()
            {
                Barrio = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al recuperar el listado de barrios",
                ListadoDeBarrios = null
            };

        }

        [HttpGet]
        [Route("ObtenerBarrioPorId")]
        public async Task<ActionResult<BarriosRespuesta>> ObtenerBarrioPorId(int id)
        {
            var listaDeBarrios = await _barriosServices.BarrioPorId(id);
            if (listaDeBarrios != null)
            {
                return new BarriosRespuesta()
                {
                    Barrio = listaDeBarrios,
                    EsExitoso = true,
                    Mensaje = "Listado de Barrios",
                    ListadoDeBarrios = null
                };
            }

            return new BarriosRespuesta()
            {
                Barrio = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al recuperar el listado de barrios",
                ListadoDeBarrios = null
            };

        }

        [HttpPut]
        [Route("ActualizarBarrio")]
        public async Task<ActionResult<BarriosRespuesta>> ActualizarBarrio(int id, [FromBody] Barrios barrio)
        {
            var listaDeBarrios = await _barriosServices.EditarBarrio(barrio);
            if (listaDeBarrios != null)
            {
                return new BarriosRespuesta()
                {
                    Barrio = listaDeBarrios,
                    EsExitoso = true,
                    Mensaje = "Listado de Barrios",
                    ListadoDeBarrios = null
                };
            }

            return new BarriosRespuesta()
            {
                Barrio = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al recuperar el listado de barrios",
                ListadoDeBarrios = null
            };

        }

        
    }
}
