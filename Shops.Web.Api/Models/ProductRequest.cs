using System;
using System.ComponentModel.DataAnnotations;

namespace Shops.Web.Api.Models
{
    public class ProductRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, 500)]
        public double Price { get; set; }
    }
}
