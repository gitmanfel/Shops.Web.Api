using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Shops.Web.Api.Context;
using Shops.Web.Api.Models;
using System;

namespace Shops.Web.Api.Tests
{
    public class RepositoryTest : ShopsContextTest
    {
        private IMapper _mapper;

        public RepositoryTest() : base(
            new DbContextOptionsBuilder<ShopsContext>()
                .UseSqlite("Filename=Test.db")
                .Options)
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = mockMapper.CreateMapper();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void When_Get_Shops_Then_Shops_Are_Retrived()
        {
            using (var context = new ShopsContext(ContextOptions))
            {
                //Arrange
                var repository = new Repository.Repository(_mapper, context);

                //Act
                var items = repository.GetShops();

                //Assert
                Assert.IsNotEmpty(items);
            }
        }

        [Test]
        public void When_Create_Shop_Then_Shop_Are_Created()
        {
            using (var context = new ShopsContext(ContextOptions))
            {
                //Arrange
                var repository = new Repository.Repository(_mapper, context);
                var shopRequest = new ShopRequest() 
                {
                    Name = "Colruyt"
                };

                //Act
                var item = repository.Insert(shopRequest);

                //Assert
                Assert.IsNotNull(item);
                Assert.AreEqual("Colruyt", item.Name);
            }
        }

        [Test]
        public void When_Delete_Shop_Then_Shop_Are_Removed()
        {
            using (var context = new ShopsContext(ContextOptions))
            {
                //Arrange
                var repository = new Repository.Repository(_mapper, context);
                var shopRequest = new ShopRequest()
                {
                    Name = "Carrefour"
                };
                var item = repository.Insert(shopRequest);

                //Act
                repository.Delete(item.Id);

                item = repository.GetShop(item.Id);

                //Assert
                Assert.IsNull(item);
            }
        }

        [Test]
        public void When_Get_Shop_By_Id_Then_Shop_Are_Retrived()
        {
            using (var context = new ShopsContext(ContextOptions))
            {
                //Arrange
                var repository = new Repository.Repository(_mapper, context);
                var shopRequest = new ShopRequest()
                {
                    Name = "C&A"
                };
                var item = repository.Insert(shopRequest);

                //Act
                item = repository.GetShop(item.Id);

                //Assert
                Assert.IsNotNull(item);
                Assert.AreEqual("C&A", item.Name);
            }
        }
        [Test]
        public Void When_Add_Product
    }
}