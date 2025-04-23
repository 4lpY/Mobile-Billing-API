using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<int> CountAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity); 
    }
}