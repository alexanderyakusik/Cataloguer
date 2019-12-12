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
            var storage = container.Resolve<DAOStorage>();

            var posterService = new PosterService(config, storage, mapper, storage.PosterDAO);

            container
                .RegisterAs<ICompanyService, CompanyService>(new CompanyService(config, storage, mapper, storage.CompanyDAO))
                .RegisterAs<IMovieService, MovieService>(new MovieService(config, storage, mapper, storage.MovieDAO, posterService))
                .RegisterAs<IQualityService, QualityService>(new QualityService(config, storage, mapper, storage.QualityDAO))
                .RegisterAs<IGenreService, GenreService>(new GenreService(config, storage, mapper, storage.GenreDAO))
                .RegisterAs<IFormatService, FormatService>(new FormatService(config, storage, mapper, storage.FormatDAO))
                .RegisterAs<IPosterService, PosterService>(posterService);
        }
    }
}
