using System;
using System.Collections.Generic;
using System.Text;

namespace DirectorioV1.Api.DataAccess.Contracts.Entities
{
    public class ClientesImagenesEntity : IEntity
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string ImageUrl { get; set; }
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
        public ClientesEntity Cliente { get; set; }
    }
}
