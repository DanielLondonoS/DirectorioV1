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
    public class BarriosController : Controller
    {
        private readonly IBarriosServices services;

        public BarriosController(IBarriosServices services)
        {
            this.services = services;
        }

        // GET: Barrios
        public IActionResult Index()
        {
            return View(this.services.ListadoDeBarrios());
        }

        // GET: Barrios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barriosEntity = await this.services.BarrioPorId(id);
            if (barriosEntity == null)
            {
                return NotFound();
            }

            return View(barriosEntity);
        }

        // GET: Barrios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Barrios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Barrios barriosEntity)
        {
            if (ModelState.IsValid)
            {
                await this.services.CrearNuevoBarrio(barriosEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(barriosEntity);
        }

        // GET: Barrios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barriosEntity = await this.services.BarrioPorId(id);
            if (barriosEntity == null)
            {
                return NotFound();
            }
            return View(barriosEntity);
        }

        // POST: Barrios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Barrios barriosEntity)
        {
            if (id != barriosEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.services.EditarBarrio(barriosEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var existe = await BarriosEntityExists(barriosEntity.Id);
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
            return View(barriosEntity);
        }

        // GET: Barrios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barriosEntity = await this.services.BarrioPorId(id);
            if (barriosEntity == null)
            {
                return NotFound();
            }

            return View(barriosEntity);
        }

        // POST: Barrios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barriosEntity = await this.services.BarrioPorId(id);
            this.services.EliminarBarrio(barriosEntity);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> BarriosEntityExists(int id)
        {
            return await this.services.ExisteBarrio(id);
        }
    }
}
