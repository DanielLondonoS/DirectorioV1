using DirectorioV1.Api.Aplication.Contracts.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectorioV1.WebApi.Controllers.Api
{
    [Route("api/[Controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriasServices categoriasServices;

        public CategoriesController(ICategoriasServices categoriasServices)
        {
            this.categoriasServices = categoriasServices;
        }

        [HttpGet]
        [Route("getCategories")]
        public IActionResult GetCategories()
        {
            return Ok(this.categoriasServices.ListadoDeCategorias());
        }
    }
}
