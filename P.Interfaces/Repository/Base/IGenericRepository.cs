using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<int> Add(T entity);
        //Task<int> AddRange(List<T> entity);
        //Task DeleteById(int id);
        Task<int> Edit(T entidad);
        //Task Edit(T entidad, T model);
        Task<List<T>> Get();
        //Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true);
        //Task<T?> GetOne(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true);
        Task<T> GetOne(Expression<Func<T, bool>> funcion);
        //Task<List<T>> Search(Expression<Func<T, bool>> funcion);
        //Task<List<T>> Search(Expression<Func<T, bool>> funcion, string incluirPropiedades);
    }
}
