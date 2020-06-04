using DirectorioV1.Api.Aplication.Contracts.Services;
using DirectorioV1.Api.Aplication.Services;
using DirectorioV1.Api.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DirectorioV1.WebApi.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriasServices services;

        public CategoriasController(ICategoriasServices services)
        {
            this.services = services;
        }

        // GET: Categorias
        public IActionResult Index()
        {
            var list = this.services.ListadoDeCategorias();
            return View(list);
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var categoriasEntity = await this.services.CategoriaPorId(id);
            if (categoriasEntity == null)
            {
                return NotFound();
            }

            return View(categoriasEntity);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categorias categoriasEntity)
        {
            if (ModelState.IsValid)
            {
                await this.services.CrearNuevoCategoria(categoriasEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(categoriasEntity);
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriasEntity = await this.services.CategoriaPorId(id);
            if (categoriasEntity == null)
            {
                return NotFound();
            }
            return View(categoriasEntity);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Categorias categoriasEntity)
        {
            if (id != categoriasEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.services.EditarCategoria(categoriasEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var exist = await CategoriasEntityExists(categoriasEntity.Id);
                    if (!exist)
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
            return View(categoriasEntity);
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriasEntity = await this.services.CategoriaPorId(id);
            if (categoriasEntity == null)
            {
                return NotFound();
            }


            return View(categoriasEntity);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriasEntity = await this.services.CategoriaPorId(id);
            this.services.EliminarCategorias(categoriasEntity); ;
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CategoriasEntityExists(int? id)
        {
            return await this.services.ExisteCategoria(id);
        }
    }
}
