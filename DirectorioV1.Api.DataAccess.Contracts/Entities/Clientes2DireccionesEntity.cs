using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Contracts.Entities
{
    public class Clientes2DireccionesEntity
    {
        public int Cliente_Id { get; set; }
        public int Direccion_Id { get; set; }

        public virtual ClientesEntity Cliente {get;set;}
        public virtual ClientesDireccionesEntity ClienteDirecciones {get;set; }
    }
}
