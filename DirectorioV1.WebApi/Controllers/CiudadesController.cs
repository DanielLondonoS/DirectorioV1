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
    public class CiudadesController : Controller
    {
        private readonly ICiudadesServices services;
        private readonly IDepartamentosServices departamentosServices;

        public CiudadesController(ICiudadesServices services, IDepartamentosServices departamentosServices)
        {
            this.services = services;
            this.departamentosServices = departamentosServices;
        }

        // GET: CiudadesConfigs
        public async Task<IActionResult> Index()
        {
            return View(await this.services.CiudadesConDepartamentos());
        }

        // GET: CiudadesConfigs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudadesEntity = await this.services.CiudadPorId(id);
            if (ciudadesEntity == null)
            {
                return NotFound();
            }
            ciudadesEntity.DepartamentosList = this.departamentosServices.ObtenerComboDepartamentos();
            ciudadesEntity.Departamento = await this.departamentosServices.DepartamentoPorId(int.Parse(ciudadesEntity.DepartamentoId));
            return View(ciudadesEntity);
        }

        // GET: CiudadesConfigs/Create
        public IActionResult Create()
        {
            Ciudades ciudades = new Ciudades();
            ciudades.DepartamentosList = this.departamentosServices.ObtenerComboDepartamentos();

            return View(ciudades);
        }

        // POST: CiudadesConfigs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ciudades ciudadesEntity)
        {
            if (ModelState.IsValid)
            {
                await this.services.CrearNuevoCiudad(ciudadesEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(ciudadesEntity);
        }

        // GET: CiudadesConfigs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudadesEntity = await this.services.CiudadPorId(id);
            if (ciudadesEntity == null)
            {
                return NotFound();
            }
            ciudadesEntity.DepartamentosList = this.departamentosServices.ObtenerComboDepartamentos();
            ciudadesEntity.Departamento = await this.departamentosServices.DepartamentoPorId(int.Parse(ciudadesEntity.DepartamentoId));
            return View(ciudadesEntity);
        }

        // POST: CiudadesConfigs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ciudades ciudadesEntity)
        {
            if (id != ciudadesEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.services.EditarCiudad(ciudadesEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var existe = await CiudadesEntityExists(ciudadesEntity.Id);
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
            return View(ciudadesEntity);
        }

        // GET: CiudadesConfigs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudadesEntity = await this.services.CiudadPorId(id);
            if (ciudadesEntity == null)
            {
                return NotFound();
            }
            ciudadesEntity.Departamento = await this.departamentosServices.DepartamentoPorId(int.Parse(ciudadesEntity.DepartamentoId));
            return View(ciudadesEntity);
        }

        // POST: CiudadesConfigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ciudadesEntity = await this.services.CiudadPorId(id);
            this.services.EliminarCiudad(ciudadesEntity);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CiudadesEntityExists(int id)
        {
            return await this.services.ExisteCiudad(id);
        }
    }
}
