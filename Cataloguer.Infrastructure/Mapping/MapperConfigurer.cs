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

        public MapperConfigurer RegisterProvider(Type sourceType, Type destType, IMappingProvider provider)
        {
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
