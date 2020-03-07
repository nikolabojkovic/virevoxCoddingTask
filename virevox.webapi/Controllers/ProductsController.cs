using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Virevox.application.core;
using Virevox.ViewModels;

namespace Virevox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductBuilder _productBuilder;
        private readonly IComparer<Product> _productComparer;
        private readonly IMapper _mapper;
        
        public ProductsController(IProductBuilder productBuilder,
                                  IComparer<Product> productComparer,
                                  IMapper mapper) 
        {
            _productBuilder = productBuilder;
            _productComparer = productComparer;
            _mapper = mapper;
        }

        [HttpGet("{consumption:long}")]
        public IEnumerable<ProductViewModel> Get(long consumption)
        {
            if (consumption < 0)
                throw new BadRequestException("Consumption have to be positive number");

            _productBuilder.SetConsumption(consumption);
            var products = _productBuilder.Build();
            Array.Sort(products, _productComparer);

            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }
    }
}
