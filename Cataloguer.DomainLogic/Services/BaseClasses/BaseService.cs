using Cataloguer.Infrastructure.Configuration;

namespace Cataloguer.DomainLogic.Services.BaseClasses
{
    public class BaseService
    {
        protected AppConfiguration Configuration { get; }

        protected BaseService(AppConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
