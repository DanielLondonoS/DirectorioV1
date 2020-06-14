using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DirectorioV1.Api.Business.Models
{
    public class ClientesImagenes
    {
        public int Id { get; set; }
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public IEnumerable<SelectListItem> ClientesList { get; set; }
        public string ImageUrl { get; set; }
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
        public bool Estado { get; set; }
        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.ImageUrl))
                {
                    return null;
                }
                return $"http://daniellondonos-001-site7.itempurl.com{this.ImageUrl.Substring(1)}";
            }
        }
        public Clientes Cliente { get; set; }
    }
}
