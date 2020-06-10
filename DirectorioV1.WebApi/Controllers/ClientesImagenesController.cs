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
using System.IO;

namespace DirectorioV1.WebApi.Controllers
{
    public class ClientesImagenesController : Controller
    {
        private readonly IClientesImagenesServices clientesImagenesServices;
        private readonly IClientesServices clientesServices;

        public ClientesImagenesController(
            IClientesImagenesServices clientesImagenesServices,
            IClientesServices clientesServices)
        {
            this.clientesImagenesServices = clientesImagenesServices;
            this.clientesServices = clientesServices;
        }

        // GET: ClientesImagenes
        public async Task<IActionResult> Index()
        {
            List<ClientesImagenes> clientesImagenes = await this.clientesImagenesServices.ListadoDeImagenesConClientes();
            return View(clientesImagenes);
        }

        // GET: ClientesImagenes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesImagenesEntity = await this.clientesImagenesServices.ImagenClientePorId(id);
            if (clientesImagenesEntity == null)
            {
                return NotFound();
            }
            clientesImagenesEntity.ClientesList = this.clientesServices.ObtenerComboClientes();
            clientesImagenesEntity.Cliente = await this.clientesServices.ClientePorId(clientesImagenesEntity.ClienteId);
            return View(clientesImagenesEntity);
        }

        // GET: ClientesImagenes/Create
        public IActionResult Create()
        {
            ClientesImagenes clientesImagenes = new ClientesImagenes();
            clientesImagenes.ClientesList = this.clientesServices.ObtenerComboClientes();
            return View(clientesImagenes);
        }

        // POST: ClientesImagenes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientesImagenes clientesImagenesEntity)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;
                if (clientesImagenesEntity.ImageFile != null && clientesImagenesEntity.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Clientes",
                        file);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await clientesImagenesEntity.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Clientes/{file}";
                }

                var newImage = this.ToProduct(clientesImagenesEntity, path);
                await this.clientesImagenesServices.CrearNuevaImagenCliente(newImage);
                return RedirectToAction(nameof(Index));
            }
            
            return View(clientesImagenesEntity);
        }

        private ClientesImagenes ToProduct(ClientesImagenes view, string path)
        {
            return new ClientesImagenes
            {
                Id = view.Id,
                ImageUrl = path,
                ClienteId = view.ClienteId,
                Estado = view.Estado,
                ImageFile = view.ImageFile,
                Cliente = view.Cliente != null ?  new Clientes {
                    Id = view.Cliente.Id,
                    Estado = view.Cliente.Estado,
                    CategoriaId = view.Cliente.CategoriaId,
                    Correo = view.Cliente.Correo,
                    Documento = view.Cliente.Documento,
                    Fecha_Creacion = view.Cliente.Fecha_Creacion,
                    Nombre = view.Cliente.Nombre,
                    Tipo_Documento = view.Cliente.Tipo_Documento
                } : null
            };
        }

        // GET: ClientesImagenes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesImagenesEntity = await this.clientesImagenesServices.ImagenClientePorId(id);
            if (clientesImagenesEntity == null)
            {
                return NotFound();
            }
            clientesImagenesEntity.ClientesList = this.clientesServices.ObtenerComboClientes();
            clientesImagenesEntity.Cliente = await this.clientesServices.ClientePorId(clientesImagenesEntity.ClienteId);
            return View(clientesImagenesEntity);
        }

        // POST: ClientesImagenes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClientesImagenes clientesImagenesEntity)
        {
            if (id != clientesImagenesEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var path = string.Empty;
                    var newImage = clientesImagenesEntity;
                    if (clientesImagenesEntity.ImageFile != null && clientesImagenesEntity.ImageFile.Length > 0)
                    {
                        var guid = Guid.NewGuid().ToString();
                        var file = $"{guid}.jpg";

                        path = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot\\images\\Clientes",
                            file);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await clientesImagenesEntity.ImageFile.CopyToAsync(stream);
                        }

                        path = $"~/images/Clientes/{file}";
                        newImage = this.ToProduct(clientesImagenesEntity, path);
                    }
                    
                    await this.clientesImagenesServices.EditarImagenCliente(newImage);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var existe = await ClientesImagenesEntityExists(clientesImagenesEntity.Id);
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
            return View(clientesImagenesEntity);
        }

        // GET: ClientesImagenes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesImagenesEntity = await this.clientesImagenesServices.ImagenClientePorId(id);
            if (clientesImagenesEntity == null)
            {
                return NotFound();
            }
            clientesImagenesEntity.ClientesList = this.clientesServices.ObtenerComboClientes();
            clientesImagenesEntity.Cliente = await this.clientesServices.ClientePorId(clientesImagenesEntity.ClienteId);
            return View(clientesImagenesEntity);
        }

        // POST: ClientesImagenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientesImagenesEntity = await this.clientesImagenesServices.ImagenClientePorId(id);
            this.clientesImagenesServices.EliminarImagenCliente(clientesImagenesEntity);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ClientesImagenesEntityExists(int id)
        {
            return await this.clientesImagenesServices.ExisteImagenCliente(id);
        }
    }
}
