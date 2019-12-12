using Cataloguer.Infrastructure.Configuration;

namespace Cataloguer.Data.DAO.BaseClasses
{
    public class BaseDAO
    {
        protected AppConfiguration Configuration { get; }

        protected BaseDAO(AppConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
