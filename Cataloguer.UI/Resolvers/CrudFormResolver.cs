using Cataloguer.DomainLogic.Interfaces.Models;
using System;
using System.Collections.Generic;

namespace Cataloguer.UI.Resolvers
{
    public class CrudFormResolver
    {
        private readonly Dictionary<Type, Type> _dict = new Dictionary<Type, Type>
        {
            { typeof(Genre), typeof(CrudForm<Genre>) },
            { typeof(Quality), typeof(CrudForm<Quality>) },
            { typeof(Format), typeof(CrudForm<Format>) },
            { typeof(Company), typeof(CrudForm<Company>) },
        };

        public Type Resolve(Type viewModelType)
        {
            if (_dict.TryGetValue(viewModelType, out Type formType))
            {
                return formType;
            }

            throw new ApplicationException($"Couldn't find factory function for type {viewModelType.Name}.");
        }
    }
}
