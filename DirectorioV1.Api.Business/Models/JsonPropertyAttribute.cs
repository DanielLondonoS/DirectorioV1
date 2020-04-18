using System;

namespace DirectorioV1.Api.Business.Models
{
    internal class JsonPropertyAttribute : Attribute
    {
        public object NullValueHandling { get; set; }
    }
}