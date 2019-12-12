using Cataloguer.DomainLogic.DependencyInjection;
using Cataloguer.Infrastructure.DependencyInjection;
using Cataloguer.Infrastructure.DependencyInjection.Interfaces;

namespace Cataloguer.ConsoleUI.DependencyInjection
{
    public class UIModule : IModule
    {
        private readonly DomainModule _domainModule;

        public UIModule()
        {
            _domainModule = new DomainModule();
        }

        public void RegisterDependencies(Container container)
        {
            _domainModule.RegisterDependencies(container);
        }
    }
}
