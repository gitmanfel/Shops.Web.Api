using System.Collections.Generic;
using Shops.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shops.Web.Api.Repository;
using System;
using AutoMapper;

namespace Shops.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly ILogger<ShopController> _logger;
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ShopController(ILogger<ShopController> logger, IRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ShopResponse> Get()
        {
            return _mapper.Map<IEnumerable<ShopResponse>>(_repository.GetShops());
        }

        [HttpGet("{id}")]
        public ShopResponse GetById([FromRoute]Guid id)
        {
            return _mapper.Map<ShopResponse>(_repository.GetShop(id));
        }

        [HttpPost]
        public ShopResponse Insert(ShopRequest request)
        {
            return _mapper.Map<ShopResponse>(_repository.Insert(request));
        }

        [HttpPut("{id}")]
        public ShopResponse Update([FromRoute]Guid id, [FromBody]ShopRequest request)
        {
            return _mapper.Map<ShopResponse>(_repository.Update(id, request));
        }

        [HttpDelete("{id}")]
        public bool Delete([FromRoute]Guid id)
        {
            _repository.Delete(id);
            return true;
        }

        [HttpPost("{id}/product")]
        public ShopResponse AddProduct([FromRoute]Guid id, [FromBody]ProductRequest request)
        {
            return _mapper.Map<ShopResponse>(_repository.AddProduct(id, request));
        }

        [HttpDelete("{id}/product/{productid}")]
        public ShopResponse RemoveProduct([FromRoute]Guid id, [FromRoute]Guid productid)
        {
            return _mapper.Map<ShopResponse>(_repository.RemoveProduct(id, productid));
        }
    }
}
