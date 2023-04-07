using Microsoft.EntityFrameworkCore;
using Shared.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataAccess.Concrete
{
    public class BaseEntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class, new()
    {
        #region Injection

        protected readonly DbContext _context;
        public BaseEntityRepository(DbContext context)
        {
            _context = context;
        }
        #endregion



        #region AddAsync
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }
        #endregion

        #region DeleteAsync
        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            await Task.Run(() => { _context.Set<TEntity>().Remove(entity); });
            return entity;
        }
        #endregion

        #region FindAsync
        public async Task<TEntity> FindAsync(object id)
        {
            return await _context.Set<TEntity>().FindAsync();
        }
        #endregion

        #region GetAllAsync
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.ToListAsync();
        }
        #endregion

        #region GetAsync
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            query = query.Where(predicate);
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.SingleOrDefaultAsync();
        }
        #endregion

        #region SaveAsync
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        #endregion

        #region UpdateAsync
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await Task.Run(() => { _context.Set<TEntity>().Update(entity); });
            return entity;
        }
        #endregion

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking().ToList();
        }
    }
}
