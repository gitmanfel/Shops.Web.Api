using Shops.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shops.Web.Api.Repository
{
    public interface IRepository
    {
        IEnumerable<Shop> GetShops();
        Shop Insert(ShopRequest request);
        Shop AddProduct(Guid id, ProductRequest request);
        Shop RemoveProduct(Guid id, Guid productid);
        Shop GetShop(Guid id);
        void Delete(Guid id);
        Shop Update(Guid id, ShopRequest request);
    }
}
