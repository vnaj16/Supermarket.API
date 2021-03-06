﻿using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<Category> FindById(int id);
        Task AddAsync(Category category);
        void Update(Category category);
        void Remove(Category category);
    }
}
