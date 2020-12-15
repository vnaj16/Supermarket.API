using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Services.Communications
{
    public class ProductResponse : BaseResponse<Product>
    {
        public ProductResponse(Product resource) : base(resource)
        {
        }

        public ProductResponse(string message) : base(message)
        {
        }
    }
}
