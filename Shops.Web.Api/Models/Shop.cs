using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shops.Web.Api.Models
{
    [Table("Shop")]
    public class Shop
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string City { get; set; }
        public List<Product> Products { get; set; }
    }
}
