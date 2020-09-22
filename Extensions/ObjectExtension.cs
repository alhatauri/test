namespace Log.Extensions
{
    public static class ObjectExtension
    {
        public static TKey GetKey<TKey>(this object obj)
        {
            var type = obj.GetType();
            var key = type
                ?.GetProperty($"{type.Name}Id")
                ?.GetValue(obj);
            return key == null
                ? default(TKey)
                : (TKey)key;
        }

        public static string GetCacheKey<TKey>(this object obj) => 
            $"{obj.GetType().Name}_{obj.GetKey<TKey>()}";

        public static string GetCacheKey<TKey, TObj>(TKey key) => 
            $"{typeof(TObj).Name}_{key}";
    }
}