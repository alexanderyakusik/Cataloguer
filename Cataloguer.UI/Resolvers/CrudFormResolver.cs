using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.UI.ViewModels;
using System;
using System.Collections.Generic;

namespace Cataloguer.UI.Resolvers
{
    public class CrudFormResolver
    {
        private readonly Dictionary<Type, Type> _dict = new Dictionary<Type, Type>
        {
            { typeof(GenreViewModel), typeof(CrudForm<GenreViewModel, Genre>) },
            { typeof(QualityViewModel), typeof(CrudForm<QualityViewModel, Quality>) },
            { typeof(FormatViewModel), typeof(CrudForm<FormatViewModel, Format>) },
            { typeof(CompanyViewModel), typeof(CrudForm<CompanyViewModel, Company>) },
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
