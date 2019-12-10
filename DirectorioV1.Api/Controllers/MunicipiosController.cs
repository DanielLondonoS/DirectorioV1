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
    public class MunicipiosController : ControllerBase
    {
        private readonly IMunicipiosServices _municipiosServices;
        public MunicipiosController(IMunicipiosServices municipiosServices)
        {
            _municipiosServices = municipiosServices;
        }

        [HttpPost]
        [Route("CrearMunicipio")]
        public async Task<ActionResult<MunisipiosRespuesta>> AgregarMunicipio([FromBody] Municipios municipios)
        {
            var Creado = await _municipiosServices.CrearNuevoMunicipio(municipios);
            if (Creado != null)
            {
                return new MunisipiosRespuesta()
                {
                    Municipio = Creado,
                    EsExitoso = true,
                    Mensaje = "Municipio Creado Exitosamente",
                    ListadoDeMunicipios = null

                };
            }

            return new MunisipiosRespuesta()
            {
                Municipio = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al crear el municipio",
                ListadoDeMunicipios = null
            };

        }
        [HttpGet]
        [Route("ObtenerMunicipios")]
        public async Task<ActionResult<MunisipiosRespuesta>> ObtenerMunicipios()
        {
            var lista = await _municipiosServices.ListadoDeMunicipios();
            if (lista != null)
            {
                return new MunisipiosRespuesta()
                {
                    Municipio = null,
                    EsExitoso = true,
                    Mensaje = "Listado de Municipios",
                    ListadoDeMunicipios = lista

                };
            }

            return new MunisipiosRespuesta()
            {
                Municipio = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al recuperar el listado de municipios",
                ListadoDeMunicipios = null
            };

        }

        [HttpGet]
        [Route("ObtenerMunicipioPorId")]
        public async Task<ActionResult<MunisipiosRespuesta>> ObtenerMunicipioPorId(int id)
        {
            var dto = await _municipiosServices.MunicipioPorId(id);
            if (dto != null)
            {
                return new MunisipiosRespuesta()
                {
                    Municipio = dto,
                    EsExitoso = true,
                    Mensaje = "Municipio encontrado",
                    ListadoDeMunicipios = null
                };
            }

            return new MunisipiosRespuesta()
            {
                Municipio = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al recuperar el Municipio",
                ListadoDeMunicipios = null
            };

        }

        [HttpPut]
        [Route("ActualizarMunicipio")]
        public async Task<ActionResult<MunisipiosRespuesta>> ActualizarMunicipio(int id, [FromBody] Municipios municipios)
        {
            var dto = await _municipiosServices.EditarMunicipio(id, municipios);
            if (dto != null)
            {
                return new MunisipiosRespuesta()
                {
                    Municipio = dto,
                    EsExitoso = true,
                    Mensaje = "Municipio Actualizado",
                    ListadoDeMunicipios = null
                };
            }

            return new MunisipiosRespuesta()
            {
                Municipio = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al actualizar el municipio",
                ListadoDeMunicipios = null
            };

        }

        
    }
}
