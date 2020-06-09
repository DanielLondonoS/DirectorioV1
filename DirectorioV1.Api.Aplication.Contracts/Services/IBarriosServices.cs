using DirectorioV1.Api.Business.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Aplication.Contracts.Services
{
    public interface IBarriosServices
    {
        Task<Barrios> EditarBarrio(Barrios dto);

        Task<Barrios> CrearNuevoBarrio(Barrios dto);

        Task<Barrios> BarrioPorId(int? id);

        List<Barrios> ListadoDeBarrios();

        void EliminarBarrio(Barrios dto);

        Task<bool> ExisteBarrio(int? id);

        IEnumerable<SelectListItem> ObtenerComboBarrios();
        Task<List<Barrios>> BarriosConCiudades();

    }
}
