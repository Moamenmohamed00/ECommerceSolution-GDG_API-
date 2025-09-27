using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Brand> Brands { get; }
        IGenericRepository<ECommerce.Domain.Entities.Type> Types { get; }
        Task<int> CompleteAsync();
    }
}
