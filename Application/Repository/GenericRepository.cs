using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class GenericRepository<T> : IGeneric<T> where T : class
    {
        private readonly ContactContext _context;
        public GenericRepository(ContactContext context) {
            _context = context;
        }
        
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }


        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>()
                .Update(entity);
        }
    }
}
