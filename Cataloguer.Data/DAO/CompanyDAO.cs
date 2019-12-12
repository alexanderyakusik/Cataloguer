using Cataloguer.Data.DAO.BaseClasses;
using Cataloguer.Data.DTO;
using Cataloguer.Infrastructure.Configuration;

namespace Cataloguer.Data.DAO
{
    public class CompanyDAO : BaseCrudDAO<CompanyDTO>
    {
        public CompanyDAO(AppConfiguration configuration) : base(configuration, configuration.CompaniesFileName)
        {
        }
    }
}
