using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrendShop.Order.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T Entity);

        // Filtrelemenin sonucu doğru ya da yanlış olarak tutulacak
        // filter --> Gönderilen Parametre
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);

    }
}
