using Cataloguer.Infrastructure.Mapping.Interfaces;

namespace Cataloguer.Infrastructure.Mapping
{
    public abstract class MappingProvider<TSource, TDest> : IMappingProvider
        where TSource : class
        where TDest : class
    {
        public abstract TDest Map(TSource source);

        public abstract TSource Map(TDest dest);

        object IMappingProvider.Map(object obj)
        {
            if (obj is TSource source)
            {
                return Map(source);
            }

            return Map((TDest)obj);
        }
    }
}
