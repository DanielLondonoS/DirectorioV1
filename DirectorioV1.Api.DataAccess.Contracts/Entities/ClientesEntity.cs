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
        [MaxLength(150, ErrorMessage = "El campo {0} solo puede contener hasta {1} caracteres.")]
        public string Nombre { get; set; }
        [DisplayName("Tipo de documento")]
        [MaxLength(100, ErrorMessage = "El campo {0} solo puede contener hasta {1} caracteres.")]
        public string Tipo_Documento { get; set; }
        [DisplayName("Número de documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} solo puede contener hasta {1} caracteres.")]
        public string Documento { get; set; }
        [DisplayName("Categoria")]
        [MaxLength(100, ErrorMessage = "El campo {0} solo puede contener hasta {1} caracteres.")]
        public int Categoria_Id { get; set; }
        [DisplayName("Fecha de creación")]
        [MaxLength(100, ErrorMessage = "El campo {0} solo puede contener hasta {1} caracteres.")]
        public DateTime? Fecha_Creacion { get; set; }
        public Boolean Estado { get; set; }
        public string Correo { get; set; }

        public ICollection<ClientesDireccionesEntity> Direcciones { get; set; }
    }
}
