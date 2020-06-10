using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DirectorioV1.Api.DataAccess;
using DirectorioV1.Api.DataAccess.Contracts.Entities;
using DirectorioV1.Api.Aplication.Contracts.Services;
using DirectorioV1.Api.Business.Models;

namespace DirectorioV1.WebApi.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClientesServices clientesServices;
        private readonly ICategoriasServices categoriasServices;

        public ClientesController(IClientesServices clientesServices,ICategoriasServices categoriasServices)
        {
            this.clientesServices = clientesServices;
            this.categoriasServices = categoriasServices;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await this.clientesServices.ListadoDeClientesConCategorias());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesEntity = await this.clientesServices.ClientePorId(id);
            if (clientesEntity == null)
            {
                return NotFound();
            }

            return View(clientesEntity);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            Clientes cliente = new Clientes();
            cliente.CategoriasList = this.categoriasServices.ObtenerComboCategorias();
            cliente.TipoDocumentoList = new List<SelectListItem>(
                new[] {
                    new SelectListItem { Value = "CC", Text = "Cedula de ciudadania" },
                    new SelectListItem { Value = "NIT", Text = "NIT" },
                    new SelectListItem { Value = "TI", Text = "Tarjeta de identidad" },
                    new SelectListItem { Value = "CE", Text = "Cedula de extrangeria" },
                });
            return View(cliente);
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Clientes clientesEntity)
        {
            if (ModelState.IsValid)
            {
                await this.clientesServices.CrearNuevoCliente(clientesEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(clientesEntity);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesEntity = await this.clientesServices.ClientePorId(id);
            if (clientesEntity == null)
            {
                return NotFound();
            }
            clientesEntity.CategoriasList = this.categoriasServices.ObtenerComboCategorias();
            clientesEntity.TipoDocumentoList = new List<SelectListItem>(
                new[] {
                    new SelectListItem { Value = "CC", Text = "Cedula de ciudadania" },
                    new SelectListItem { Value = "NIT", Text = "NIT" },
                    new SelectListItem { Value = "TI", Text = "Tarjeta de identidad" },
                    new SelectListItem { Value = "CE", Text = "Cedula de extrangeria" },
                });
            return View(clientesEntity);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Clientes clientesEntity)
        {
            if (id != clientesEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.clientesServices.EditarCliente(clientesEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var existe = await ClientesEntityExists(clientesEntity.Id);
                    if (!existe)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clientesEntity);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesEntity = await this.clientesServices.ClientePorId(id);
            if (clientesEntity == null)
            {
                return NotFound();
            }

            return View(clientesEntity);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientesEntity = await this.clientesServices.ClientePorId(id);
            this.clientesServices.EliminarCliente(clientesEntity);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ClientesEntityExists(int id)
        {
            return await this.clientesServices.ExisteCliente(id);
        }
    }
}
