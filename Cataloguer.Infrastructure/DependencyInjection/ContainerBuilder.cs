using Cataloguer.Infrastructure.Classes;
using Cataloguer.Infrastructure.DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cataloguer.Infrastructure.DependencyInjection
{
    public class ContainerBuilder
    {
        private readonly List<Action<Container>> _actions = new List<Action<Container>>();

        public ContainerBuilder()
        {
            Reflection.ForceLoadAssemblies();
        }

        public Container Build()
        {
            var container = new Container();

            _actions.ForEach(action => action(container));
            RegisterDependencies(container);

            return container;
        }

        internal void RegisterAction(Action<Container> action)
        {
            _actions.Add(action);
        }

        private void RegisterDependencies(Container container)
        {
            IEnumerable<IModule> modules = Reflection
                .GetTypesInheritedFrom<IModule>()
                .Select(type => (IModule)Activator.CreateInstance(type))
                .OrderBy(module => module.Order);

            foreach (var module in modules)
            {
                module.RegisterDependencies(container);
            }
        }
    }
}
