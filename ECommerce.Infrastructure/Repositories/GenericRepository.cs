using ECommerce.Application.Interfaces;
using ECommerce.Persistence._Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace ECommerce.Infrastructure.Repositories
{
    internal class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        private readonly ECommerceDb _context;
        public GenericRepository(ECommerceDb context)
        {
            _context = context;
        }
        public async Task<T> GetByIdAsync(int id) =>
            await _context.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync() =>
            await _context.Set<T>().ToListAsync();

        public async Task AddAsync(T entity) =>
            await _context.Set<T>().AddAsync(entity);

        public void Update(T entity) =>
            _context.Set<T>().Update(entity);

        public void Delete(T entity) =>
            _context.Set<T>().Remove(entity);

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) =>
            await _context.Set<T>().Where(predicate).ToListAsync();
    }
}
