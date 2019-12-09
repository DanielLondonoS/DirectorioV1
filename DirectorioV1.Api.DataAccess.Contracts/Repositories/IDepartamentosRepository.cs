﻿using DirectorioV1.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioV1.Api.DataAccess.Contracts.Repositories
{
    public interface IDepartamentosRepository : IRepository<DepartamentosEntity>
    {
        Task<DepartamentosEntity> Update(DepartamentosEntity element);
    }
}
