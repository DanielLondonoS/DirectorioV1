using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Contracts.Entities
{
    public class CategoriasEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public virtual ClientesEntity Clientes { get; set; }
    }
}
