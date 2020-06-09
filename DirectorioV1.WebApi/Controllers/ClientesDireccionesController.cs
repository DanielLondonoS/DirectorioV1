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
    public class ClientesDireccionesController : Controller
    {
        private readonly IClientesDireccionesServices clientesDireccionesServices;
        private readonly IClientesServices clientesServices;
        private readonly IBarriosServices barriosServices;
        private readonly IPaisesServices paisesServices;
        private readonly ICiudadesServices ciudadesServices;
        private readonly IDepartamentosServices departamentosServices;
        
        public ClientesDireccionesController(
            IClientesDireccionesServices clientesDireccionesServices,
            IClientesServices clientesServices,
            IBarriosServices barriosServices,
            IPaisesServices paisesServices,
            ICiudadesServices ciudadesServices,
            IDepartamentosServices departamentosServices
            )
        {
            this.clientesDireccionesServices = clientesDireccionesServices;
            this.clientesServices = clientesServices;
            this.barriosServices = barriosServices;
            this.paisesServices = paisesServices;
            this.ciudadesServices = ciudadesServices;
            this.departamentosServices = departamentosServices;
        }

        // GET: ClientesDirecciones
        public async Task<IActionResult> Index()
        {
            var clientes = await this.clientesDireccionesServices.ListadoDeDireccionesConClientes();
            return View(clientes);
        }

        // GET: ClientesDirecciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesDireccionesEntity = await this.clientesDireccionesServices.DireccionClientePorId(id);
            if (clientesDireccionesEntity == null)
            {
                return NotFound();
            }
            clientesDireccionesEntity.BarriosList = this.barriosServices.ObtenerComboBarrios();
            clientesDireccionesEntity.PaisesList = this.paisesServices.ObtenerComboPaises();
            clientesDireccionesEntity.CiudadesList = this.ciudadesServices.ObtenerComboCiudades();
            clientesDireccionesEntity.DepartamentosList = this.departamentosServices.ObtenerComboDepartamentos();
            clientesDireccionesEntity.ClientesList = this.clientesServices.ObtenerComboClientes();
            clientesDireccionesEntity.DireccionTiposAList = new List<SelectListItem>(
                new[] {
                    new SelectListItem { Value = "Calle", Text = "Celle" },
                    new SelectListItem { Value = "Carrera", Text = "Carrera" },
                    new SelectListItem { Value = "Circular", Text = "Circular" },
                    new SelectListItem { Value = "Transversal", Text = "Transversal" },
                    new SelectListItem { Value = "Avenida", Text = "Avenida" },
                });
            return View(clientesDireccionesEntity);
        }

        // GET: ClientesDirecciones/Create
        public IActionResult Create()
        {
            ClientesDirecciones clientesDireccionesEntity = new ClientesDirecciones();
            clientesDireccionesEntity.BarriosList = this.barriosServices.ObtenerComboBarrios();
            clientesDireccionesEntity.PaisesList = this.paisesServices.ObtenerComboPaises();
            clientesDireccionesEntity.CiudadesList = this.ciudadesServices.ObtenerComboCiudades();
            clientesDireccionesEntity.DepartamentosList = this.departamentosServices.ObtenerComboDepartamentos();
            clientesDireccionesEntity.ClientesList = this.clientesServices.ObtenerComboClientes();
            clientesDireccionesEntity.DireccionTiposAList = new List<SelectListItem>(
                new[] {
                    new SelectListItem { Value = "Calle", Text = "Celle" },
                    new SelectListItem { Value = "Carrera", Text = "Carrera" },
                    new SelectListItem { Value = "Circular", Text = "Circular" },
                    new SelectListItem { Value = "Transversal", Text = "Transversal" },
                    new SelectListItem { Value = "Avenida", Text = "Avenida" },
                });
            return View(clientesDireccionesEntity);
        }

        // POST: ClientesDirecciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientesDirecciones clientesDireccionesEntity)
        {
            if (ModelState.IsValid)
            {
                await this.clientesDireccionesServices.CrearNuevaDireccionCliente(clientesDireccionesEntity);
                return RedirectToAction(nameof(Index));
            }
            
            return View(clientesDireccionesEntity);
        }

        // GET: ClientesDirecciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesDireccionesEntity = await this.clientesDireccionesServices.DireccionClientePorId(id);
            if (clientesDireccionesEntity == null)
            {
                return NotFound();
            }
            clientesDireccionesEntity.BarriosList = this.barriosServices.ObtenerComboBarrios();
            clientesDireccionesEntity.PaisesList = this.paisesServices.ObtenerComboPaises();
            clientesDireccionesEntity.CiudadesList = this.ciudadesServices.ObtenerComboCiudades();
            clientesDireccionesEntity.DepartamentosList = this.departamentosServices.ObtenerComboDepartamentos();
            clientesDireccionesEntity.ClientesList = this.clientesServices.ObtenerComboClientes();
            clientesDireccionesEntity.DireccionTiposAList = new List<SelectListItem>(
                new[] {
                    new SelectListItem { Value = "Calle", Text = "Celle" },
                    new SelectListItem { Value = "Carrera", Text = "Carrera" },
                    new SelectListItem { Value = "Circular", Text = "Circular" },
                    new SelectListItem { Value = "Transversal", Text = "Transversal" },
                    new SelectListItem { Value = "Avenida", Text = "Avenida" },
                });
            return View(clientesDireccionesEntity);
        }

        // POST: ClientesDirecciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClientesDirecciones clientesDireccionesEntity)
        {
            if (id != clientesDireccionesEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.clientesDireccionesServices.EditarDireccionCliente(clientesDireccionesEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var existe = await ClientesDireccionesEntityExists(clientesDireccionesEntity.Id);
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
            
            return View(clientesDireccionesEntity);
        }

        // GET: ClientesDirecciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesDireccionesEntity = await this.clientesDireccionesServices.DireccionClientePorId(id);
            if (clientesDireccionesEntity == null)
            {
                return NotFound();
            }

            return View(clientesDireccionesEntity);
        }

        // POST: ClientesDirecciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientesDireccionesEntity = await this.clientesDireccionesServices.DireccionClientePorId(id);
            this.clientesDireccionesServices.EliminarDireccionCliente(clientesDireccionesEntity);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ClientesDireccionesEntityExists(int id)
        {
            return await this.clientesDireccionesServices.ExisteDireccionCliente(id);
        }
    }
}
