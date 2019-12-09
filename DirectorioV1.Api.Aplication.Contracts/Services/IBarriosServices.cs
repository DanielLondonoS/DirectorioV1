﻿using DirectorioV1.Api.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioV1.Api.Aplication.Contracts.Services
{
    public interface IBarriosServices
    {
        Task<Barrios> EditarBarrio(int id, Barrios dto);

        Task<Barrios> CrearNuevoBarrio(Barrios dto);

        Task<Barrios> BarrioPorId(int id);

        Task<List<Barrios>> ListadoDeBarrios();
    }
}