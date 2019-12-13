using Cataloguer.Infrastructure.Mapping.Interfaces;

namespace Cataloguer.Infrastructure.Mapping
{
    public abstract class MappingProvider<T1, T2> : IMappingProvider
        where T1 : class
        where T2 : class
    {
        public abstract T2 Map(T1 source);

        public abstract T1 Map(T2 dest);

        object IMappingProvider.Map(object obj)
        {
            if (obj is T1 source)
            {
                return Map(source);
            }

            return Map((T2)obj);
        }
    }
}
