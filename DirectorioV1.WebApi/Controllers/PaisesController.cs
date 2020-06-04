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
    public class PaisesController : Controller
    {
        private readonly IPaisesServices services;

        public PaisesController(IPaisesServices services)
        {
            this.services = services;
        }

        // GET: Paises
        public IActionResult Index()
        {
            return View(this.services.ListadoDePaises());
        }

        // GET: Paises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paisesEntity = await this.services.PaisPorId(id);
            if (paisesEntity == null)
            {
                return NotFound();
            }

            return View(paisesEntity);
        }

        // GET: Paises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Paises paisesEntity)
        {
            if (ModelState.IsValid)
            {
                await this.services.CrearNuevoPais(paisesEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(paisesEntity);
        }

        // GET: Paises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paisesEntity = await this.services.PaisPorId(id);
            if (paisesEntity == null)
            {
                return NotFound();
            }
            return View(paisesEntity);
        }

        // POST: Paises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Paises paisesEntity)
        {
            if (id != paisesEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.services.EditarPais(paisesEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var existe = await PaisesEntityExists(paisesEntity.Id);
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
            return View(paisesEntity);
        }

        // GET: Paises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paisesEntity = await this.services.PaisPorId(id);
            if (paisesEntity == null)
            {
                return NotFound();
            }

            return View(paisesEntity);
        }

        // POST: Paises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paisesEntity = await services.PaisPorId(id);
            this.services.EliminarPais(paisesEntity);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PaisesEntityExists(int? id)
        {
            return await this.services.ExistePais(id);
        }
    }
}
