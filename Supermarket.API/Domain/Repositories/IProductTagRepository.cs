using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Repositories
{
    public interface IProductTagRepository
    {
        Task<IEnumerable<ProductTag>> ListAsync();
        Task<IEnumerable<ProductTag>> ListByProductIdAsync(int productId);
        Task<IEnumerable<ProductTag>> ListByTagIdAsync(int tagId);
        Task<IEnumerable<ProductTag>> FindByProductIdAndTagId(int productId, int tagId);
        Task AddAsync(ProductTag productTag);
        void Remove(ProductTag productTag);
        Task AssignProducTTag(int productId, int tagId);
        void UnassignProducTTag(int productId, int tagId);
    }
}
