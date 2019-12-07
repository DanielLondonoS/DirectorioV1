using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Contracts.Entities
{
    public class ClientesEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo_Documento { get; set; }
        public string Documento { get; set; }
        public int Categoria_Id { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public Boolean Estado { get; set; }
        public string Correo { get; set; }

        public virtual ICollection<Clientes2DireccionesEntity> Clientes2Direcciones { get; set; }
        public virtual CategoriasEntity Categoria { get; set; }
    }
}
