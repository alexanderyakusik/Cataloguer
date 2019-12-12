using Cataloguer.Data.DAO;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.DomainLogic.Services;
using Cataloguer.Infrastructure.Configuration;
using Cataloguer.Infrastructure.DependencyInjection;
using Cataloguer.Infrastructure.DependencyInjection.Interfaces;
using Cataloguer.Infrastructure.Mapping;

namespace Cataloguer.DomainLogic.DependencyInjection
{
    public class DomainModule : IModule
    {
        public int Order => 2;

        public void RegisterDependencies(Container container)
        {
            var config = container.Resolve<AppConfiguration>();
            var mapper = container.Resolve<Mapper>();

            container
                .RegisterAs<ICompanyService, CompanyService>(new CompanyService(config, mapper, container.Resolve<CompanyDAO>()))
                .RegisterAs<IMovieService, MovieService>(new MovieService(config, mapper, container.Resolve<MovieDAO>()))
                .RegisterAs<IQualityService, QualityService>(new QualityService(config, mapper, container.Resolve<QualityDAO>()))
                .RegisterAs<IGenreService, GenreService>(new GenreService(config, mapper, container.Resolve<GenreDAO>()))
                .RegisterAs<IFormatService, FormatService>(new FormatService(config, mapper, container.Resolve<FormatDAO>()))
                .RegisterAs<IPosterService, PosterService>(new PosterService(config, mapper, container.Resolve<PosterDAO>()));
        }
    }
}
