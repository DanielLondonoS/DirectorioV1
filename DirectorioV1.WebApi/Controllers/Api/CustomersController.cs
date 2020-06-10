using DirectorioV1.Api.Aplication.Contracts.Services;
using DirectorioV1.Api.Business.Models;
using DirectorioV1.Api.DataAccess.Contracts.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectorioV1.WebApi.Controllers.Api
{
    [Route("api/[Controller]")]
    public class CustomersController : Controller
    {
        private readonly IClientesServices clientesServices;

        public CustomersController(IClientesServices clientesServices)
        {
            this.clientesServices = clientesServices;
        }

        [HttpGet]
        [Route("getCustomers")]
        public async Task<ActionResult<ICollection<Clientes>>> GetCustomer()
        {
            return Ok(await this.clientesServices.ListadoDeClientesConDatos());            
        }
    }
}
