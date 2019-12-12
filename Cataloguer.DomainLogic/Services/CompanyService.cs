using Cataloguer.Data.DAO.BaseClasses;
using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.DomainLogic.Services.BaseClasses;
using Cataloguer.Infrastructure.Configuration;
using Cataloguer.Infrastructure.Mapping;

namespace Cataloguer.DomainLogic.Services
{
    public class CompanyService : BaseNamedCrudService<Company, CompanyDTO>, ICompanyService
    {
        public CompanyService(AppConfiguration configuration, Mapper mapper, BaseCrudDAO<CompanyDTO> dao) : base(configuration, mapper, dao)
        {
        }
    }
}
