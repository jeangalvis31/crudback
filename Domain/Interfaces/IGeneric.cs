using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGeneric<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        Task<T> GetByIdAsync(int id);
    }
}
