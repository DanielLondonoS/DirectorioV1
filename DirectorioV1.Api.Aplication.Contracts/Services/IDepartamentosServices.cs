using DirectorioV1.Api.Business.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Aplication.Contracts.Services
{
    public interface IDepartamentosServices
    {
        Task<Departamentos> EditarDepartamento(Departamentos dto);

        Task<Departamentos> CrearNuevoDepartamento(Departamentos dto);

        Task<Departamentos> DepartamentoPorId(int? id);

        List<Departamentos> ListadoDeDepartamentos();
        void EliminarDepartamento(Departamentos dto);

        Task<bool> ExisteDepartamento(int? id);

        Task<List<Departamentos>> DepartamentosConPais();
        IEnumerable<SelectListItem> ObtenerComboDepartamentos();
    }
}
