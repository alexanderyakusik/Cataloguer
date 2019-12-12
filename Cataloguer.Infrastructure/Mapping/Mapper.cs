using Cataloguer.Infrastructure.Mapping.Interfaces;
using System;
using System.Collections.Generic;

namespace Cataloguer.Infrastructure.Mapping
{
    public class Mapper
    {
        public readonly Dictionary<Type, Dictionary<Type, IMappingProvider>> _dict;

        internal Mapper(MapperConfigurer configurer)
        {
            _dict = configurer.ProvidersConfiguration;
        }

        public TDest Map<TDest>(object source)
        {
            Type sourceType = source?.GetType();
            Type destType = typeof(TDest);

            if (_dict.TryGetValue(sourceType, out Dictionary<Type, IMappingProvider> innerDict))
            {
                if (innerDict.TryGetValue(destType, out IMappingProvider provider))
                {
                    return (TDest)provider.Map(source);
                }
            }

            throw new ApplicationException($"Couldn't map {sourceType?.Name} to {destType.Name}. Be sure to register a mapping provider.");
        }
    }
}
