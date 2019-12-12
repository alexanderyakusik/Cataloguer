using Cataloguer.Data.DAO;
using Cataloguer.Data.DependencyInjection;
using Cataloguer.DomainLogic.Services;
using Cataloguer.Infrastructure.Configuration;
using Cataloguer.Infrastructure.DependencyInjection;
using Cataloguer.Infrastructure.DependencyInjection.Interfaces;

namespace Cataloguer.DomainLogic.DependencyInjection
{
    public class DomainModule : IModule
    {
        private readonly DataModule _dataModule;

        public DomainModule()
        {
            _dataModule = new DataModule();
        }

        public void RegisterDependencies(Container container)
        {
            _dataModule.RegisterDependencies(container);

            var config = container.Resolve<AppConfiguration>();
            var posterService = new PosterService(config, container.Resolve<PosterDAO>(), container.Resolve<PosterImageDAO>());

            container
                .Register(posterService)
                .Register(new MovieService(config, container.Resolve<MovieDAO>(), posterService))
                .Register(new FormatService(config, container.Resolve<FormatDAO>()))
                .Register(new QualityService(config, container.Resolve<QualityDAO>()))
                .Register(new CompanyService(config, container.Resolve<CompanyDAO>()))
                .Register(new GenreService(config, container.Resolve<GenreDAO>()));
        }
    }
}
