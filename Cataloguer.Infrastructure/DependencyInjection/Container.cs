using System;
using System.Collections.Generic;

namespace Cataloguer.Infrastructure.DependencyInjection
{
    public class Container
    {
        private readonly Dictionary<Type, object> _dict = new Dictionary<Type, object>();

        internal Container()
        {
        }

        public T Resolve<T>()
        {
            Type type = typeof(T);

            if (_dict.TryGetValue(type, out object value))
            {
                return (T)value;
            }

            throw new ApplicationException($"Cannod resolve instance of the type {type.Name}.");
        }

        public Container Register<T>(T @object)
        {
            _dict[typeof(T)] = @object;

            return this;
        }

        public Container RegisterAs<TAs, T>(T @object)
        {
            _dict[typeof(TAs)] = @object;

            return this;
        }
    }
}
