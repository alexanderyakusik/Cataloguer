using Cataloguer.Infrastructure.Configuration;
using Cataloguer.Infrastructure.DependencyInjection.Interfaces;

namespace Cataloguer.Infrastructure.DependencyInjection
{
    public class InfrastructureModule : IModule
    {
        public int Order => int.MinValue;

        public void RegisterDependencies(Container container)
        {
            container
                .Register(new AppConfiguration())
                .Register(new Initializer(container.Resolve<AppConfiguration>()));
        }
    }
}
