using DirectorioV1.Api.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Aplication.Contracts.Services
{
    public interface IMunicipiosServices
    {
        Task<Municipios> EditarMunicipio(int id, Municipios dto);

        Task<Municipios> CrearNuevoMunicipio(Municipios dto);

        Task<Municipios> MunicipioPorId(int id);

        Task<List<Municipios>> ListadoDeMunicipios();
    }
}
