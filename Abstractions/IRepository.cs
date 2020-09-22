using System.Collections.Generic;

namespace Log.Abstractions
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        void Create(TEntity item);
        TEntity Get(TKey id);
        IList<TEntity> Get();
        void Delete(TEntity item);
        void Update(TEntity item);
    }
}