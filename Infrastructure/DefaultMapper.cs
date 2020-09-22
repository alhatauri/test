using System;
using Log.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Log.Infrastructure
{
    public class DefaultMapper : IMapper
    {
        readonly IServiceProvider _sp;

        public DefaultMapper(IServiceProvider sp) => _sp = sp;

        public TOut Map<TIn, TOut>(TIn value)
        {
            var map = _sp.GetRequiredService<Startup.Map<TIn, TOut>>() 
                ?? throw new NotImplementedException($"{nameof(Startup.Map<TIn, TOut>)}");
            return map(value);
        }
    }
}