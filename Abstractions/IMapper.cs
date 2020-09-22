namespace Log.Abstractions
{
    public interface IMapper
    {
        TOut Map<TIn, TOut>(TIn value);
    }
}