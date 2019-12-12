using Cataloguer.Infrastructure.Mapping.Interfaces;
using System;
using System.Collections.Generic;

namespace Cataloguer.Infrastructure.Mapping
{
    internal class MapperConfigurer
    {
        public Dictionary<Type, Dictionary<Type, IMappingProvider>> ProvidersConfiguration { get; }

        public MapperConfigurer()
        {
            ProvidersConfiguration = new Dictionary<Type, Dictionary<Type, IMappingProvider>>();
        }

        public MapperConfigurer RegisterProvider<TSource, TDest>(MappingProvider<TSource, TDest> provider)
            where TSource : class
            where TDest : class
        {
            Type sourceType = typeof(TSource);
            Type destType = typeof(TDest);

            if (ProvidersConfiguration.TryGetValue(sourceType, out Dictionary<Type, IMappingProvider> innerDict))
            {
                innerDict.Add(destType, provider);
            }
            else
            {
                ProvidersConfiguration.Add(sourceType, new Dictionary<Type, IMappingProvider> { { destType, provider } });
            }

            return this;
        }
    }
}
