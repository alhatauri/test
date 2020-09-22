namespace Log.Abstractions
{
    public interface ICacheService<TDTO, TEntity, TKey>
    where TDTO : class
    where TEntity : class
    where TKey : struct
    {
        TDTO Get(TKey id);
        TKey Create(TDTO item);
        void Update(TDTO item);
        TDTO Delete(TKey id);
    }
}