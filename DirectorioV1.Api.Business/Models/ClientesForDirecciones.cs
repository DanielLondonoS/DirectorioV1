using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.Business.Models
{
    public class ClientesForDirecciones
    {
        public Clientes Cliente { get; set; }
        public List<ClientesDirecciones> ClienteDirecciones { get; set; }
    }
}
