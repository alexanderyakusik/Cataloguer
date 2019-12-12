using Cataloguer.Data.DAO.BaseClasses;
using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.DomainLogic.Services.BaseClasses;
using Cataloguer.Infrastructure.Configuration;
using Cataloguer.Infrastructure.Mapping;

namespace Cataloguer.DomainLogic.Services
{
    public class QualityService : BaseNamedCrudService<Quality, QualityDTO>, IQualityService
    {
        public QualityService(AppConfiguration configuration, Mapper mapper, BaseCrudDAO<QualityDTO> dao) : base(configuration, mapper, dao)
        {
        }
    }
}
