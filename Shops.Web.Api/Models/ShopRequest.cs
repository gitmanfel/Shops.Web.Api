using System.ComponentModel.DataAnnotations;

namespace Shops.Web.Api.Models
{
    public class ShopRequest
    {
        [Required]
        public string Name { get; set; }
        public string OwnerName { get; set; }
        [Required]
        public string City { get; set; }
    }
}
