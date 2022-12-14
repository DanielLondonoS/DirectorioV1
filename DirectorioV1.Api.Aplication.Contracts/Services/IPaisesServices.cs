using DirectorioV1.Api.Business.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Aplication.Contracts.Services
{
    public interface IPaisesServices
    {
        Task<Paises> EditarPais(Paises dto);

        Task<Paises> CrearNuevoPais(Paises dto);

        Task<Paises> PaisPorId(int? id);

        List<Paises> ListadoDePaises();
        void EliminarPais(Paises dto);

        Task<bool> ExistePais(int? id);

        IEnumerable<SelectListItem> ObtenerComboPaises();

    }
}
