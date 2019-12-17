using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.Infrastructure.DependencyInjection;
using Cataloguer.Infrastructure.DependencyInjection.Interfaces;
using Cataloguer.Infrastructure.Mapping;
using Cataloguer.UI.Adapters;
using Cataloguer.UI.FormControls.Models;
using Cataloguer.UI.Resolvers;
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
            var movieAdapter = new MovieListViewAdapter();

            container
                .RegisterAs<IListViewAdapter<Company>, CompanyListViewAdapter>(companyAdapter)
                .RegisterAs<IListViewAdapter<Quality>, NamedBaseListViewAdapter>(qualityAdapter)
                .RegisterAs<IListViewAdapter<Format>, NamedBaseListViewAdapter>(formatAdapter)
                .RegisterAs<IListViewAdapter<Genre>, NamedBaseListViewAdapter>(genreAdapter)
                .Register(() => new CrudForm<Company>(
                    container.Resolve<ICompanyService>(),
                    companyAdapter,
                    mapper,
                    (company, isCreateMode) => new CrudEditorForm<Company>(company, isCreateMode, new CompanyFormControl())
                ))
                .Register(() => new CrudForm<Quality>(
                    container.Resolve<IQualityService>(),
                    qualityAdapter,
                    mapper,
                    (quality, isCreateMode) => new CrudEditorForm<Quality>(quality, isCreateMode, new QualityFormControl())
                ))
                .Register(() => new CrudForm<Format>(
                    container.Resolve<IFormatService>(),
                    formatAdapter,
                    mapper,
                    (format, isCreateMode) => new CrudEditorForm<Format>(format, isCreateMode, new FormatFormControl())
                ))
                .Register(() => new CrudForm<Genre>(
                    container.Resolve<IGenreService>(),
                    genreAdapter,
                    mapper,
                    (genre, isCreateMode) => new CrudEditorForm<Genre>(genre, isCreateMode, new GenreFormControl())
                ));

            var resolver = new CrudFormResolver();
            Func<Type, Form> crudFormFactory = (Type type) =>
            {
                Type crudFormType = resolver.Resolve(type);

                return (Form)container.Resolve(crudFormType);
            };

            container
                .Register(() => new MovieForm(
                    crudFormFactory,
                    container.Resolve<IMovieService>(),
                    movieAdapter,
                    mapper,
                    (movie, isCreateMode) => new CrudEditorForm<MovieViewModel>(movie, isCreateMode, new MovieFormControl())
                ));
        }
    }
}
