using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Repositories
{
    public interface IUnitOfWork //Su trabajo es realizar los commit, transacciones
    {
        Task CompleteAsync();
    }
}
