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
    public class CiudadesController : ControllerBase
    {
        private readonly ICiudadesServices _ciudadesServices;
        public CiudadesController(ICiudadesServices ciudadesServices)
        {
            _ciudadesServices = ciudadesServices;
        }

        [HttpPost]
        [Route("CrearCiudad")]
        public async Task<ActionResult<CiudadesRespuesta>> AgregaCiudad([FromBody] Ciudades ciudades)
        {
            var Creado = await _ciudadesServices.CrearNuevoCiudad(ciudades);
            if (Creado != null)
            {
                return new CiudadesRespuesta()
                {
                    Ciudad = Creado,
                    EsExitoso = true,
                    Mensaje = "Ciudad Creada Exitosamente",
                    ListadoDeCiudades = null

                };
            }

            return new CiudadesRespuesta()
            {
                Ciudad = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al crear la ciudad",
                ListadoDeCiudades = null
            };

        }
        [HttpGet]
        [Route("ObtenerCiudades")]
        public ActionResult<CiudadesRespuesta> ObtenerCiudades()
        {
            var lista = _ciudadesServices.ListadoDeCiudades();
            if (lista != null)
            {
                return new CiudadesRespuesta()
                {
                    Ciudad = null,
                    EsExitoso = true,
                    Mensaje = "Listado de Ciudades",
                    ListadoDeCiudades = lista

                };
            }

            return new CiudadesRespuesta()
            {
                Ciudad = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al recuperar el listado de ciudades",
                ListadoDeCiudades = null
            };

        }

        [HttpGet]
        [Route("ObtenerCiudadPorId")]
        public async Task<ActionResult<CiudadesRespuesta>> ObtenerCiudadPorId(int id)
        {
            var dto = await _ciudadesServices.CiudadPorId(id);
            if (dto != null)
            {
                return new CiudadesRespuesta()
                {
                    Ciudad = dto,
                    EsExitoso = true,
                    Mensaje = "Ciudad encontrado",
                    ListadoDeCiudades = null
                };
            }

            return new CiudadesRespuesta()
            {
                Ciudad = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al recuperar la ciudad",
                ListadoDeCiudades = null
            };

        }

        [HttpPut]
        [Route("ActualizarCiudad")]
        public async Task<ActionResult<CiudadesRespuesta>> ActualizarCiudad(int id, [FromBody] Ciudades ciudades)
        {
            var dto = await _ciudadesServices.EditarCiudad(ciudades);
            if (dto != null)
            {
                return new CiudadesRespuesta()
                {
                    Ciudad = dto,
                    EsExitoso = true,
                    Mensaje = "Ciudad Actualizada",
                    ListadoDeCiudades = null
                };
            }

            return new CiudadesRespuesta()
            {
                Ciudad = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al actualizar la ciudad",
                ListadoDeCiudades = null
            };

        }

        
    }
}
