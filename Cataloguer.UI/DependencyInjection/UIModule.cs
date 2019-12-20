using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.DomainLogic.Interfaces.Models.Search;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.Infrastructure.DependencyInjection;
using Cataloguer.Infrastructure.DependencyInjection.Interfaces;
using Cataloguer.UI.Adapters;
using Cataloguer.UI.Enums;
using Cataloguer.UI.FormControls.Models;
using Cataloguer.UI.Providers.Dropdown;
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
                    (company, isCreateMode) => new CrudEditorForm<Company>(company, isCreateMode, new CompanyFormControl())
                ))
                .Register(() => new CrudForm<Quality>(
                    container.Resolve<IQualityService>(),
                    qualityAdapter,
                    (quality, isCreateMode) => new CrudEditorForm<Quality>(quality, isCreateMode, new QualityFormControl())
                ))
                .Register(() => new CrudForm<Format>(
                    container.Resolve<IFormatService>(),
                    formatAdapter,
                    (format, isCreateMode) => new CrudEditorForm<Format>(format, isCreateMode, new FormatFormControl())
                ))
                .Register(() => new CrudForm<Genre>(
                    container.Resolve<IGenreService>(),
                    genreAdapter,
                    (genre, isCreateMode) => new CrudEditorForm<Genre>(genre, isCreateMode, new GenreFormControl())
                ));

            var resolver = new CrudFormResolver();
            Func<Type, Form> crudFormFactory = (Type type) =>
            {
                Type crudFormType = resolver.Resolve(type);

                return (Form)container.Resolve(crudFormType);
            };

            Func<MovieFormControl> movieEditorFormControlFactory = () => new MovieFormControl(
                new NamedBaseDropdownValuesProvider<Company>(container.Resolve<ICompanyService>()),
                new NamedBaseDropdownValuesProvider<Genre>(container.Resolve<IGenreService>()),
                new NamedBaseDropdownValuesProvider<Quality>(container.Resolve<IQualityService>()),
                new NamedBaseDropdownValuesProvider<Format>(container.Resolve<IFormatService>())
            );

            Func<MovieSearchFormControl> movieSearchFormControlFactory = () => new MovieSearchFormControl(
                new NamedBaseDropdownValuesProvider<Company>(container.Resolve<ICompanyService>()),
                new NamedBaseDropdownValuesProvider<Genre>(container.Resolve<IGenreService>()),
                new NamedBaseDropdownValuesProvider<Quality>(container.Resolve<IQualityService>()),
                new NamedBaseDropdownValuesProvider<Format>(container.Resolve<IFormatService>())
            );

            container
                .Register(() => new MovieForm(
                    crudFormFactory,
                    container.Resolve<IMovieService>(),
                    movieAdapter,
                    (movie, viewType) => new CrudEditorForm<Movie>(movie, viewType, movieEditorFormControlFactory()),
                    () => new CrudEditorForm<MovieSearchModel>(default, ViewType.Search, movieSearchFormControlFactory()),
                    (id) => new MovieDetailsForm(id, container.Resolve<IMovieService>())
                ));
        }
    }
}
