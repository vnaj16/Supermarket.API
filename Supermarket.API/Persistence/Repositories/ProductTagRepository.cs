using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Contexts;
using Supermarket.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence.Repositories
{
    public class ProductTagRepository : BaseRepository, IProductTagRepository
    {
        public ProductTagRepository(AppDbContext context) : base(context)
        {
        }

        public Task AddAsync(ProductTag productTag)
        {
            throw new NotImplementedException();
        }

        public Task AssignProducTTag(int productId, int tagId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductTag>> FindByProductIdAndTagId(int productId, int tagId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductTag>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductTag>> ListByProductIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductTag>> ListByTagIdAsync(int tagId)
        {
            throw new NotImplementedException();
        }

        public void Remove(ProductTag productTag)
        {
            throw new NotImplementedException();
        }

        public void UnassignProducTTag(int productId, int tagId)
        {
            throw new NotImplementedException();
        }
    }
}
