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
    public class PaisesController : ControllerBase
    {
        private readonly IPaisesServices _paisesServices;
        public PaisesController(IPaisesServices paisesServices)
        {
            _paisesServices = paisesServices;
        }

        [HttpPost]
        [Route("CrearPais")]
        public async Task<ActionResult<PaisesRespuesta>> AgregarPais([FromBody] Paises barrio)
        {
            var Creado = await _paisesServices.CrearNuevoPais(barrio);
            if (Creado != null)
            {
                return new PaisesRespuesta()
                {
                    Pais = Creado,
                    EsExitoso = true,
                    Mensaje = "Pais Creado Exitosamente",
                    ListadoDePaises = null

                };
            }

            return new PaisesRespuesta()
            {
                Pais = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al crear el pais",
                ListadoDePaises = null
            };

        }
        [HttpGet]
        [Route("ObtenerPaises")]
        public async Task<ActionResult<PaisesRespuesta>> ObtenerPaises()
        {
            var lista = _paisesServices.ListadoDePaises();
            if (lista != null)
            {
                return new PaisesRespuesta()
                {
                    Pais = null,
                    EsExitoso = true,
                    Mensaje = "Listado de Paises",
                    ListadoDePaises = lista

                };
            }

            return new PaisesRespuesta()
            {
                Pais = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al recuperar el listado de barrios",
                ListadoDePaises = null
            };

        }

        [HttpGet]
        [Route("ObtenerPaisPorId")]
        public async Task<ActionResult<PaisesRespuesta>> ObtenerPaisPorId(int id)
        {
            var dto = await _paisesServices.PaisPorId(id);
            if (dto != null)
            {
                return new PaisesRespuesta()
                {
                    Pais = dto,
                    EsExitoso = true,
                    Mensaje = "Listado de Paises",
                    ListadoDePaises = null
                };
            }

            return new PaisesRespuesta()
            {
                Pais = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al recuperar el listado de paises",
                ListadoDePaises = null
            };

        }

        [HttpPut]
        [Route("ActualizarPais")]
        public async Task<ActionResult<PaisesRespuesta>> ActualizarPais(int id, [FromBody] Paises paises)
        {
            var dto = await _paisesServices.EditarPais(paises);
            if (dto != null)
            {
                return new PaisesRespuesta()
                {
                    Pais = dto,
                    EsExitoso = true,
                    Mensaje = "Listado de paises",
                    ListadoDePaises = null
                };
            }

            return new PaisesRespuesta()
            {
                Pais = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al recuperar el listado de paises",
                ListadoDePaises = null
            };

        }

        
    }
}
