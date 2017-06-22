using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MinProjMVC.DataAccessLayer;
using System.Threading.Tasks;

namespace MinProjMVC.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private DbSet<TEntity> _dbSet;
        private msgdbEntities _context;

        public GenericRepository(msgdbEntities context)
        {
            this._context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual IQueryable<TEntity> GetQueryable()
        {
            return _dbSet;
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

    }
}