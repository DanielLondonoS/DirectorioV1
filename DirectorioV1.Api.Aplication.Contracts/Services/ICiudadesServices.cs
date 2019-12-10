using DirectorioV1.Api.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Aplication.Contracts.Services
{
    public interface ICiudadesServices
    {
        Task<Ciudades> EditarCiudad(int id, Ciudades dto);

        Task<Ciudades> CrearNuevoCiudad(Ciudades dto);

        Task<Ciudades> CiudadPorId(int id);

        Task<List<Ciudades>> ListadoDeCiudades();
    }
}
