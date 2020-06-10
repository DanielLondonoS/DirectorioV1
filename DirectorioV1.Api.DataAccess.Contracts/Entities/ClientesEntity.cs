using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Contracts.Entities
{
    public class ClientesEntity : IEntity
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Correo { get; set; }
        public string Tipo_Documento { get; set; }
        [MaxLength(20)]
        public string Documento { get; set; }
        public DateTime? Fecha_Creacion { get; set; }
        public Boolean Estado { get; set; } 
        
        public int CategoriaId { get; set; }
        public CategoriasEntity Categoria { get; set; }
        public ICollection<ClientesDireccionesEntity> Direcciones { get; set; }
        public ICollection<ClientesImagenesEntity> Imagenes { get; set; }
    }
}
