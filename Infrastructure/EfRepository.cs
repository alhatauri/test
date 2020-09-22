using System;
using System.Collections.Generic;
using System.Linq;
using Log.Abstractions;
using Log.Models;
using Microsoft.EntityFrameworkCore;

namespace Log.Infrastructure
{
    public class EfRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class
    {
        readonly LogsContext _context;
        readonly DbSet<TEntity> _dbSet;

        public EfRepository(LogsContext context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
            _dbSet = context.Set<TEntity>();
        }
        public TEntity Get(TKey id)
        {
            return _dbSet.Find(id);
        }
        public IList<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }
        public void Create(TEntity item)
        {
            _dbSet.Add(item);
        }
        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
        public void Update(IEnumerable<TEntity> item)
        {
            _context.UpdateRange(item);
        }
        public void Delete(TEntity item)
        {
            _dbSet.Remove(item);
        }
    }
}