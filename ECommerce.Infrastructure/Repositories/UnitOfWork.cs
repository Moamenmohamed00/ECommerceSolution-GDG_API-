using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Persistence._Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ECommerce.Infrastructure.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ECommerceDb _context;
        public UnitOfWork(ECommerceDb context)
        {
            _context = context;
            Products = new GenericRepository<Product>(_context);
            Brands = new GenericRepository<Brand>(_context);
            Types = new GenericRepository<ECommerce.Domain.Entities.Type>(_context);
        }

        public IGenericRepository<Product> Products { get; private set; }
        public IGenericRepository<Brand> Brands { get; private set; }
        public IGenericRepository<ECommerce.Domain.Entities.Type> Types { get; private set; }

        public async Task<int> CompleteAsync() =>
            await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
