using Library.Helpers.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
namespace Library.Helpers.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        protected DbSet<T> DbSet;
        public Repository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }
        public async Task<T> GetAsync(params object[] keys)
        {
            return await DbSet.FindAsync(keys);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (include != null)
            {
                query = include(query);
            }
            try
            {
                var x = await query.FirstOrDefaultAsync();
                return x;

            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate = null, IEnumerable<SortModel> orderByCriteria = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (orderByCriteria != null)
            {
                query = query.OrderBy(orderByCriteria);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (include != null)
            {
                query = include(query);
            }
            return await query.ToListAsync();
        }
        public async Task<(int, IEnumerable<T>)> FindPagedAsync(Expression<Func<T, bool>> predicate = null, int skip = 0, int take = 0, IEnumerable<SortModel> orderByCriteria = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            int count = query.Count();

            if (orderByCriteria != null)
            {
                var field = orderByCriteria.First().PairAsSqlExpression;
                query = query.OrderBy(field);
            }

            if (take > 0 && take >0)
            {
                query = query.Skip(skip).Take(take);
            }
            
            if (include != null)
            {
                query = include(query);
            }
            return (count, await query.ToListAsync());
        }
        public async Task<IEnumerable<T>> GetAllAsync(IEnumerable<SortModel> orderByCriteria = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            if (include != null)
            {
                query = include(query);
            }
            if (orderByCriteria != null)
            {
                query = query.OrderBy(orderByCriteria);
            }
            return await query.ToListAsync();
        }

        public async Task<ICollection<TType>> GetSelectAsync<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select) where TType : class
        {
            return await DbSet.Where(where).Select(select).ToListAsync();
        }
        public async Task<IEnumerable<TType>> FindSelectAsync<TType>(Expression<Func<T, TType>> select, Expression<Func<T, bool>> predicate = null, IEnumerable<SortModel> orderByCriteria = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true) where TType : class
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (orderByCriteria != null)
            {
                query = query.OrderBy(orderByCriteria);
            }
            if (include != null)
            {
                query = include(query);
            }
            return await query.Select(select).ToListAsync();
        }
        public async Task<(int, IEnumerable<TType>)> FindPagedSelectAsync<TType>(Expression<Func<T, TType>> select, Expression<Func<T, bool>> predicate = null, int skip = 0, int take = 0, IEnumerable<SortModel> orderByCriteria = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true) where TType : class
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (include != null)
            {
                query = include(query);
            }
            var count = query.Count();
            if (orderByCriteria == null) return (count, await query.Skip(skip).Take(take).Select(select).ToListAsync());
            var field = orderByCriteria.First().PairAsSqlExpression;
            query = query.OrderBy(field).Skip(skip).Take(take);

            return (count, await query.Select(select).ToListAsync());
        }

        public async Task<bool> Any(Expression<Func<T, bool>> predicate = null) => predicate == null ? await DbSet.AnyAsync() : await DbSet.AnyAsync(predicate);

        public async Task<int> Count(Expression<Func<T, bool>> predicate = null) => predicate == null ? await DbSet.CountAsync() : await DbSet.CountAsync(predicate);

        public T Add(T newEntity)
        {
            return DbSet.Add(newEntity).Entity;
        }
        public void AddRange(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
        }
        public void Update(T originalEntity, T newEntity)
        {
            Context.Entry(originalEntity).CurrentValues.SetValues(newEntity);
        }
        public async Task UpdateAsync(long id, T newEntity)
        {
            var originalEntity = await DbSet.FindAsync(id);
            Context.Entry(originalEntity).CurrentValues.SetValues(newEntity);
        }
        public void UpdateRange(IEnumerable<T> newEntities)
        {
            Context.UpdateRange(newEntities);
        }
        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }
        public void RemoveLogical(T entity)
        {
            var type = entity.GetType();
            var property = type.GetProperty("IsBlock");
            if (property != null) property.SetValue(entity, true);
            var id = type.GetProperty("Id")?.GetValue(entity);
            var original = DbSet.Find(id);
            Update(original, entity);
        }
        public async void Remove(Expression<Func<T, bool>> predicate)
        {
            var objects = await DbSet.FindAsync(predicate);
            DbSet.RemoveRange(objects);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }
        public long GetNextSequenceValue(string sequenceName)
        {
            var value = Context.GetNextSequenceValue(sequenceName);
            return value;
        }
    }
   
}
