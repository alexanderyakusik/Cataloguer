using Cataloguer.Data.DAO;
using Cataloguer.Infrastructure.Configuration;

namespace Cataloguer.DomainLogic.Services.BaseClasses
{
    public class BaseService
    {
        protected AppConfiguration Configuration { get; }

        protected DAOStorage Storage { get; }

        protected BaseService(AppConfiguration configuration, DAOStorage storage)
        {
            Configuration = configuration;
            Storage = storage;
        }
    }
}
