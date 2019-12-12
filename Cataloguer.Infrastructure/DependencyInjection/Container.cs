using Cataloguer.Infrastructure.DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;

namespace Cataloguer.Infrastructure.DependencyInjection
{
    public class Container
    {
        private readonly Dictionary<Type, object> _dict = new Dictionary<Type, object>();

        public Container(IModule module)
        {
            new InfrastructureModule().RegisterDependencies(this);

            module.RegisterDependencies(this);
        }

        public T Resolve<T>()
        {
            Type type = typeof(T);

            if (_dict.TryGetValue(type, out object value))
            {
                return (T)value;
            }

            throw new ApplicationException($"Cannod resolve instance of a type {type.Name}.");
        }

        public Container Register<T>(T @object)
        {
            _dict[typeof(T)] = @object;

            return this;
        }
    }
}
