using Cataloguer.Infrastructure.DependencyInjection;
using Cataloguer.Infrastructure.DependencyInjection.Interfaces;

namespace Cataloguer.ConsoleUI.DependencyInjection
{
    public class UIModule : IModule
    {
        public int Order => 3;

        public void RegisterDependencies(Container container)
        {
        }
    }
}
