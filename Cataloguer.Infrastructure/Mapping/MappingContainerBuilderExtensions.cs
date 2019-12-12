using Cataloguer.Infrastructure.Classes;
using Cataloguer.Infrastructure.DependencyInjection;
using Cataloguer.Infrastructure.Mapping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cataloguer.Infrastructure.Mapping
{
    public static class MappingContainerBuilderExtensions
    {
        public static ContainerBuilder WithMapper(this ContainerBuilder containerBuilder)
        {
            Action<Container> action = container =>
            {
                var configurer = new MapperConfigurer();
                RegisterProviders(configurer);
                container.Register(new Mapper(configurer));
            };

            containerBuilder.RegisterAction(action);

            return containerBuilder;
        }

        private static void RegisterProviders(MapperConfigurer configurer)
        {
            IEnumerable<Type> mappingProvidersTypes = Reflection
                .GetTypesInheritedFrom<IMappingProvider>()
                .Where(type => type != typeof(MappingProvider<,>));

            foreach (Type providerType in mappingProvidersTypes)
            {
                IMappingProvider provider = (IMappingProvider)Activator.CreateInstance(providerType);
                Type[] genericArguments = providerType.BaseType.GetGenericArguments();

                configurer.RegisterProvider(genericArguments[0], genericArguments[1], provider);
            }
        }
    }
}
