using Cataloguer.Data.DAO.BaseClasses;
using Cataloguer.Data.DTO;
using Cataloguer.Infrastructure.Configuration;

namespace Cataloguer.Data.DAO
{
    public class QualityDAO : BaseCrudDAO<QualityDTO>
    {
        public QualityDAO(AppConfiguration configuration) : base(configuration, configuration.QualitiesFileName)
        {
        }
    }
}
