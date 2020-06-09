using DirectorioV1.Api.Business.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Aplication.Contracts.Services
{
    public interface ICategoriasServices
    {
        Task<Categorias> EditarCategoria(Categorias dto);

        Task<Categorias> CrearNuevoCategoria(Categorias dto);

        Task<Categorias> CategoriaPorId(int? id);

        List<Categorias> ListadoDeCategorias();
        void EliminarCategorias(Categorias dto);

        Task<bool> ExisteCategoria(int? id);

        IEnumerable<SelectListItem> ObtenerComboCategorias();
    }
}
