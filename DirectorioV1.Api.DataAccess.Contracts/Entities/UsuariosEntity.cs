using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Contracts.Entities
{
    public class UsuariosEntity : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
