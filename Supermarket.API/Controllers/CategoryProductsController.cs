using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Resources;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/categories/{categoryId}/products")]
    public class CategoryProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CategoryProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List products by category",
            Description = "List of Products for an specific Category",
            OperationId = "ListProductsByCategory",
            Tags = new [] {"Categories"})]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductResource>), 200)]
        public async Task<IEnumerable<ProductResource>> GetAllByCategoryIdAsync(int categoryId)
        {
            var products = await _productService.ListByCategoryIdAsync(categoryId);
            var resource = _mapper
                .Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return resource;
        }      
    }
}
