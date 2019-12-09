﻿using DirectorioV1.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioV1.Api.DataAccess.Contracts.Repositories
{
    public interface ICategoriasRepository : IRepository<CategoriasEntity>
    {
        Task<CategoriasEntity> Update(CategoriasEntity element);
    }
}