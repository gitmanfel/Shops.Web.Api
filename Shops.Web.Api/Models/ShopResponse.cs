using System;
using System.Collections.Generic;

namespace Shops.Web.Api.Models
{
    public class ShopResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string City { get; set; }
        public List<ProductResponse> Products { get; set; }
    }
}
