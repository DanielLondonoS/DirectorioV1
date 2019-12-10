using DirectorioV1.Api.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Aplication.Contracts.Services
{
    public interface ICategoriasServices
    {
        Task<Categorias> EditarCategoria(int id, Categorias dto);

        Task<Categorias> CrearNuevoCategoria(Categorias dto);

        Task<Categorias> CategoriaPorId(int id);

        Task<List<Categorias>> ListadoDeCategorias();
    }
}
