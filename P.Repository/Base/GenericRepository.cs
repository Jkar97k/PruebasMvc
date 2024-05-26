using Microsoft.EntityFrameworkCore;
using P.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> Get()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<int> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<T?> GetOne(Expression<Func<T, bool>> funcion)
        {
            return await _context.Set<T>().AsNoTracking().Where(funcion).FirstOrDefaultAsync();
        }

        public async Task<int> Edit(T entidad)
        {
            _context.Set<T>().Attach(entidad);
            _context.Entry(entidad).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteByguid(Expression<Func<T, bool>> funcion)
        {
            var entity = await _context.Set<T>().AsNoTracking().Where(funcion).FirstOrDefaultAsync();
            if (entity != null)
            {
                _context.Remove(entity);
                return await _context.SaveChangesAsync();

            }
            return 0;
        }

        //public async Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
        //                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //                       string includeString = null,
        //                       bool disableTracking = true)
        //{
        //    IQueryable<T> query = _context.Set<T>();
        //    if (disableTracking) query = query.AsNoTracking();

        //    if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

        //    if (predicate != null) query = query.Where(predicate);

        //    if (orderBy != null)
        //        return await orderBy(query).ToListAsync();


        //    return await query.ToListAsync();
        //}

        //public async Task<T?> GetOne(Expression<Func<T, bool>> predicate = null,
        //                          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //                          List<Expression<Func<T, object>>> includes = null,
        //                          bool disableTracking = true)
        //{
        //    IQueryable<T> query = _context.Set<T>();
        //    if (disableTracking) query = query.AsNoTracking();

        //    if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

        //    if (predicate != null) query = query.Where(predicate);

        //    if (orderBy != null)
        //        return await orderBy(query).FirstOrDefaultAsync();

        //    return await query.FirstOrDefaultAsync();
        //}



        //public async Task<List<T>> Search(Expression<Func<T, bool>> funcion)
        //{
        //    return await _context.Set<T>().AsNoTracking().Where(funcion).ToListAsync();
        //}

        //public async Task<List<T>> Search(Expression<Func<T, bool>> funcion, string incluirPropiedades)
        //{
        //    IQueryable<T> peticion = _context.Set<T>().AsNoTracking().Where(funcion);
        //    return await IncluirPropiedades(peticion, incluirPropiedades).ToListAsync();
        //}



        //public async Task<int> AddRange(List<T> entity)
        //{
        //    await _context.Set<T>().AddRangeAsync(entity);
        //    return await _context.SaveChangesAsync();
        //}



        //public async Task Edit(T entidad, T model)
        //{
        //    _context.Entry(entidad).CurrentValues.SetValues(model);
        //    _context.Entry(entidad).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //}



        //private IQueryable<T> IncluirPropiedades(IQueryable<T> peticion, string incluirPropiedades)
        //{
        //    foreach (string incluirPropiedad in incluirPropiedades.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        peticion = peticion.Include(incluirPropiedad);
        //    }
        //    return peticion;
        //}
    }
}
