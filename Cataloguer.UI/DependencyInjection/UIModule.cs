using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.Infrastructure.DependencyInjection;
using Cataloguer.Infrastructure.DependencyInjection.Interfaces;
using Cataloguer.Infrastructure.Mapping;
using Cataloguer.UI.Adapters;
using Cataloguer.UI.Resolvers;
using Cataloguer.UI.ViewModels;
using System;
using System.Windows.Forms;

namespace Cataloguer.UI.DependencyInjection
{
    public class UIModule : IModule
    {
        public int Order => 3;

        public void RegisterDependencies(Container container)
        {
            var mapper = container.Resolve<Mapper>();

            var companyAdapter = new CompanyListViewAdapter();
            var qualityAdapter = new QualityListViewAdapter();
            var formatAdapter = new FormatListViewAdapter();
            var genreAdapter = new GenreListViewAdapter();

            container
                .RegisterAs<IListViewAdapter<CompanyViewModel>, CompanyListViewAdapter>(companyAdapter)
                .RegisterAs<IListViewAdapter<QualityViewModel>, NamedBaseListViewAdapter>(qualityAdapter)
                .RegisterAs<IListViewAdapter<FormatViewModel>, NamedBaseListViewAdapter>(formatAdapter)
                .RegisterAs<IListViewAdapter<GenreViewModel>, NamedBaseListViewAdapter>(genreAdapter)
                .Register(() => new CrudForm<CompanyViewModel, Company>(container.Resolve<ICompanyService>(), companyAdapter, mapper))
                .Register(() => new CrudForm<QualityViewModel, Quality>(container.Resolve<IQualityService>(), qualityAdapter, mapper))
                .Register(() => new CrudForm<FormatViewModel, Format>(container.Resolve<IFormatService>(), formatAdapter, mapper))
                .Register(() => new CrudForm<GenreViewModel, Genre>(container.Resolve<IGenreService>(), genreAdapter, mapper));

            var resolver = new CrudFormResolver();

            container
                .Register(() => new Cataloguer((Type type) => 
                {
                    Type crudFormType = resolver.Resolve(type);

                    return (Form)container.Resolve(crudFormType);
                }));
        }
    }
}
