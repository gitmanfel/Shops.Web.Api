using Shops.Web.Api.Models;
using Shops.Web.Api.Context;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Shops.Web.Api.Repository
{
    public class Repository : IRepository
    {
        private IMapper _mapper;
        private ShopsContext _dbcontext;

        public Repository(IMapper mapper, ShopsContext dbcontext)
        {
            _mapper = mapper;
            _dbcontext = dbcontext;
        }

        public Shop AddProduct(Guid id, ProductRequest request)
        {
            var shop = _dbcontext.Shops.FirstOrDefault(x => x.Id == id);
            var product = _mapper.Map<Product>(request);

            if (shop.Products == null)
                shop.Products = new List<Product>();

            shop.Products.Add(product);

            _dbcontext.SaveChanges();

            return shop;
        }

        public void Delete(Guid id)
        {
            var shop = _dbcontext.Shops.FirstOrDefault(x => x.Id == id);
            _dbcontext.Remove(shop);
            _dbcontext.SaveChanges();
        }

        public Shop GetShop(Guid id)
        {
            var shop = _dbcontext.Shops.Include(x => x.Products).FirstOrDefault(x => x.Id == id);
            return shop;
        }

        public IEnumerable<Shop> GetShops()
        {
            return _dbcontext.Shops.Include(x => x.Products).ToList();
        }

        public Shop Insert(ShopRequest request)
        {
            var shop = _mapper.Map<Shop>(request);

            _dbcontext.Shops.Add(shop);

            _dbcontext.SaveChanges();

            return shop;
        }

        public Shop RemoveProduct(Guid id, Guid productid)
        {
            var product = _dbcontext.Products.FirstOrDefault(x => x.Id == productid);
            _dbcontext.Remove(product);
            _dbcontext.SaveChanges();

            return _dbcontext.Shops.Include(x => x.Products).FirstOrDefault(x => x.Id == id);
        }

        public Shop Update(Guid id, ShopRequest request)
        {
            var shop = _mapper.Map<Shop>(request);
            shop.Id = id;
            _dbcontext.Update(shop);
            _dbcontext.SaveChanges();

            return _dbcontext.Shops.Include(x => x.Products).FirstOrDefault(x => x.Id == id);
        }
    }
}
