using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.Business.Models
{
    public class Clientes
    {
        public Clientes()
        {
            this.Direcciones = new List<ClientesDirecciones>();
            this.Imagenes = new List<ClientesImagenes>();
            this.Categoria = new Categorias();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo_Documento { get; set; }
        public IEnumerable<SelectListItem> TipoDocumentoList { get; set; }
        public string Documento { get; set; }
        public int CategoriaId { get; set; }
        public IEnumerable<SelectListItem> CategoriasList { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public Boolean Estado { get; set; }
        public string Correo { get; set; }

        public ICollection<ClientesDirecciones> Direcciones { get; set; }
        public ICollection<ClientesImagenes> Imagenes { get; set; }
        public Categorias Categoria { get; set; }
    }
}
