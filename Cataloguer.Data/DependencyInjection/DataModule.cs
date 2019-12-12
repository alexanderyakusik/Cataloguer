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

            var daoStorage = new DAOStorage(
                new CompanyDAO(config),
                new FormatDAO(config),
                new GenreDAO(config),
                new PosterDAO(config),
                new QualityDAO(config),
                new MovieDAO(config),
                new PosterImageDAO(config)
            );

            container.Register(daoStorage);
        }
    }
}
