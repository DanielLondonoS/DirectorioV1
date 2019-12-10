using DirectorioV1.Api.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Aplication.Contracts.Services
{
    public interface IPaisesServices
    {
        Task<Paises> EditarPais(int id, Paises dto);

        Task<Paises> CrearNuevoPais(Paises dto);

        Task<Paises> PaisPorId(int id);

        Task<List<Paises>> ListadoDePaises();
    }
}
