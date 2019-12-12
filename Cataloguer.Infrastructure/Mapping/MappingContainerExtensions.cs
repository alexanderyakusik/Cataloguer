using Cataloguer.Infrastructure.DependencyInjection;
using Cataloguer.Infrastructure.Mapping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cataloguer.Infrastructure.Mapping
{
    public static class MappingContainerExtensions
    {
        public static Container WithMapper(this Container container)
        {
            var configurer = new MapperConfigurer();
            RegisterProviders(configurer);
            container.Register(new Mapper(configurer));

            return container;
        }

        private static void RegisterProviders(MapperConfigurer configurer)
        {
            IEnumerable<Type> mappingProvidersTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => typeof(IMappingProvider).IsAssignableFrom(type))
                .Where(type => type != typeof(IMappingProvider) && type != typeof(MappingProvider<,>));

            foreach (Type providerType in mappingProvidersTypes)
            {
                IMappingProvider provider = (IMappingProvider)Activator.CreateInstance(providerType);
                Type[] genericArguments = providerType.BaseType.GetGenericArguments();

                configurer.RegisterProvider(genericArguments[0], genericArguments[1], provider);
            }
        }
    }
}
