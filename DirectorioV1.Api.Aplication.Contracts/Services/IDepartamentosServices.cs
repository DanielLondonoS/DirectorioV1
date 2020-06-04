using DirectorioV1.Api.Business.Models;
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
    }
}
