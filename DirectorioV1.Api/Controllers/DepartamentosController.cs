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
    public class DepartamentosController : ControllerBase
    {
        private readonly IDepartamentosServices _departamentosServices;
        public DepartamentosController(IDepartamentosServices departamentosServices)
        {
            _departamentosServices = departamentosServices;
        }

        [HttpPost]
        [Route("CrearDepartamento")]
        public async Task<ActionResult<DepartamentosRespuesta>> AgregarDepartamento([FromBody] Departamentos departamentos)
        {
            var Creado = await _departamentosServices.CrearNuevoDepartamento(departamentos);
            if (Creado != null)
            {
                return new DepartamentosRespuesta()
                {
                    Departamento = Creado,
                    EsExitoso = true,
                    Mensaje = "Departamento Creado Exitosamente",
                    ListadoDeDepartamentos = null

                };
            }

            return new DepartamentosRespuesta()
            {
                Departamento = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al crear el departamento",
                ListadoDeDepartamentos = null
            };

        }
        [HttpGet]
        [Route("ObtenerDepartamentos")]
        public async Task<ActionResult<DepartamentosRespuesta>> ObtenerDepartamentos()
        {
            var lista = await _departamentosServices.ListadoDeDepartamentos();
            if (lista != null)
            {
                return new DepartamentosRespuesta()
                {
                    Departamento = null,
                    EsExitoso = true,
                    Mensaje = "Listado de departamentos",
                    ListadoDeDepartamentos = lista

                };
            }

            return new DepartamentosRespuesta()
            {
                Departamento = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al recuperar el listado de departamentos",
                ListadoDeDepartamentos = null
            };

        }

        [HttpGet]
        [Route("ObtenerDepartamentoPorId")]
        public async Task<ActionResult<DepartamentosRespuesta>> ObtenerDepartamentoPorId(int id)
        {
            var dto = await _departamentosServices.DepartamentoPorId(id);
            if (dto != null)
            {
                return new DepartamentosRespuesta()
                {
                    Departamento = dto,
                    EsExitoso = true,
                    Mensaje = "Listado de Paises",
                    ListadoDeDepartamentos = null
                };
            }

            return new DepartamentosRespuesta()
            {
                Departamento = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al recuperar el listado de departamentos",
                ListadoDeDepartamentos = null
            };

        }

        [HttpPut]
        [Route("ActualizarPais")]
        public async Task<ActionResult<DepartamentosRespuesta>> ActualizarPais(int id, [FromBody] Departamentos departamentos)
        {
            var dto = await _departamentosServices.EditarDepartamento(id, departamentos);
            if (dto != null)
            {
                return new DepartamentosRespuesta()
                {
                    Departamento = dto,
                    EsExitoso = true,
                    Mensaje = "Listado de departamentos",
                    ListadoDeDepartamentos = null
                };
            }

            return new DepartamentosRespuesta()
            {
                Departamento = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al recuperar el listado de departamentos",
                ListadoDeDepartamentos = null
            };

        }

        
    }
}
