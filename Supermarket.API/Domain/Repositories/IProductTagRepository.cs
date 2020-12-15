﻿using Supermarket.API.Domain.Models;
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
        Task<ProductTag> FindByProductIdAndTagId(int productId, int tagId);
        Task AddAsync(ProductTag productTag);
        void Remove(ProductTag productTag);
        Task AssignProductTag(int productId, int tagId);
        void UnassignProductTag(int productId, int tagId);
    }
}
