using Cataloguer.Data.DAO;
using Cataloguer.Infrastructure.Configuration;
using Cataloguer.Infrastructure.DependencyInjection;
using Cataloguer.Infrastructure.DependencyInjection.Interfaces;

namespace Cataloguer.Data.DependencyInjection
{
    public class DataModule : IModule
    {
        public int Order => 1;

        public void RegisterDependencies(Container container)
        {
            var config = container.Resolve<AppConfiguration>();

            container
                .Register(new MovieDAO(config))
                .Register(new PosterDAO(config))
                .Register(new PosterImageDAO(config))
                .Register(new GenreDAO(config))
                .Register(new QualityDAO(config))
                .Register(new FormatDAO(config))
                .Register(new CompanyDAO(config));
        }
    }
}
