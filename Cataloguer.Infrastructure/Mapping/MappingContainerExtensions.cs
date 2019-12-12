using Cataloguer.Infrastructure.DependencyInjection;
using System;
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
            var mappingProviders = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => typeof(MappingProvider<,>).IsAssignableFrom(type));
        }
    }
}
