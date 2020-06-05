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
    public class DepartamentosController : Controller
    {
        private readonly IDepartamentosServices services;

        public DepartamentosController(IDepartamentosServices services)
        {
            this.services = services;
        }

        // GET: Departamentos
        public IActionResult Index()
        {
            return View(this.services.ListadoDeDepartamentos());
        }

        // GET: Departamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentosEntity = await this.services.DepartamentoPorId(id);
            if (departamentosEntity == null)
            {
                return NotFound();
            }

            return View(departamentosEntity);
        }

        // GET: Departamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Departamentos departamentosEntity)
        {
            if (ModelState.IsValid)
            {
                await this.services.CrearNuevoDepartamento(departamentosEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(departamentosEntity);
        }

        // GET: Departamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentosEntity = await this.services.DepartamentoPorId(id);
            if (departamentosEntity == null)
            {
                return NotFound();
            }
            return View(departamentosEntity);
        }

        // POST: Departamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Departamentos departamentosEntity)
        {
            if (id != departamentosEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.services.EditarDepartamento(departamentosEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var existe = await DepartamentosEntityExists(departamentosEntity.Id);
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
            return View(departamentosEntity);
        }

        // GET: Departamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentosEntity = await this.services.DepartamentoPorId(id);
            if (departamentosEntity == null)
            {
                return NotFound();
            }

            return View(departamentosEntity);
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamentosEntity = await this.services.DepartamentoPorId(id);
            this.services.EliminarDepartamento(departamentosEntity);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> DepartamentosEntityExists(int id)
        {
            return await this.services.ExisteDepartamento(id);
        }

        public async Task<IActionResult> DepartametosConPais()
        {

            var departamentosEntity = await this.services.DepartamentosConPais();
            if (departamentosEntity == null)
            {
                return NotFound();
            }

            return View(departamentosEntity);
        }
    }
}
