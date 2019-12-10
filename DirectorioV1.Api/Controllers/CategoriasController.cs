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
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasServices _categoriasServices;
        public CategoriasController(ICategoriasServices categoriasServices)
        {
            _categoriasServices = categoriasServices;
        }

        [HttpPost]
        [Route("CrearCategoria")]
        public async Task<ActionResult<CategoriasRespuesta>> AgregarCategoria([FromBody] Categorias categoria)
        {
            var Creado = await _categoriasServices.CrearNuevoCategoria(categoria);
            if (Creado != null)
            {
                return new CategoriasRespuesta()
                {
                    Categoria = Creado,
                    EsExitoso = true,
                    Mensaje = "Categoria Creada Exitosamente",
                    ListadoDeCategorias = null

                };
            }

            return new CategoriasRespuesta()
            {
                Categoria = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al crear la categoria",
                ListadoDeCategorias = null
            };

        }
        [HttpGet]
        [Route("ObtenerCategorias")]
        public async Task<ActionResult<CategoriasRespuesta>> ObtenerCategorias()
        {
            var lista = await _categoriasServices.ListadoDeCategorias();
            if (lista != null)
            {
                return new CategoriasRespuesta()
                {
                    Categoria = null,
                    EsExitoso = true,
                    Mensaje = "Listado de categorias",
                    ListadoDeCategorias = lista

                };
            }

            return new CategoriasRespuesta()
            {
                Categoria = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al recuperar el listado de categorias",
                ListadoDeCategorias = null
            };

        }

        [HttpGet]
        [Route("ObtenerCategoriaPorId")]
        public async Task<ActionResult<CategoriasRespuesta>> ObtenerCategoriaPorId(int id)
        {
            var dto = await _categoriasServices.CategoriaPorId(id);
            if (dto != null)
            {
                return new CategoriasRespuesta()
                {
                    Categoria = dto,
                    EsExitoso = true,
                    Mensaje = "Listado de categorias",
                    ListadoDeCategorias = null
                };
            }

            return new CategoriasRespuesta()
            {
                Categoria = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al recuperar el listado de categorias",
                ListadoDeCategorias = null
            };

        }

        [HttpPut]
        [Route("ActualizarCategoria")]
        public async Task<ActionResult<CategoriasRespuesta>> ActualizarCategoria(int id, [FromBody] Categorias categorias)
        {
            var dto = await _categoriasServices.EditarCategoria(id, categorias);
            if (dto != null)
            {
                return new CategoriasRespuesta()
                {
                    Categoria = dto,
                    EsExitoso = true,
                    Mensaje = "Listado de categorias",
                    ListadoDeCategorias = null
                };
            }

            return new CategoriasRespuesta()
            {
                Categoria = null,
                EsExitoso = false,
                Mensaje = "Ocurrio un error al recuperar el listado de categorias",
                ListadoDeCategorias = null
            };

        }

        
    }
}
