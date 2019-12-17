using Cataloguer.Infrastructure.Mapping.Interfaces;

namespace Cataloguer.Infrastructure.Mapping
{
    public abstract class MappingProvider<T1, T2> : IMappingProvider
        where T1 : class
        where T2 : class
    {
        public abstract T2 Map(T1 source, Mapper mapper);

        public abstract T1 Map(T2 dest, Mapper mapper);

        object IMappingProvider.Map(object obj, Mapper mapper)
        {
            if (obj is T1 source)
            {
                return Map(source, mapper);
            }

            return Map((T2)obj, mapper);
        }
    }
}
