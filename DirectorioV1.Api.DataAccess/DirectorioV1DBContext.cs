using DirectorioV1.Api.DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess
{
    public class DirectorioV1DBContext : DbContext, IDirectorioV1DBContext
    {
        

        public DirectorioV1DBContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
