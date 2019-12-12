using Cataloguer.Data.DAO.BaseClasses;
using Cataloguer.Data.DTO;
using Cataloguer.Infrastructure.Configuration;

namespace Cataloguer.Data.DAO
{
    public class FormatDAO : BaseCrudDAO<FormatDTO>
    {
        public FormatDAO(AppConfiguration configuration) : base(configuration, configuration.FormatsFileName)
        {
        }
    }
}
