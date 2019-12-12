using Cataloguer.Data.DAO.BaseClasses;
using Cataloguer.Data.DTO;
using Cataloguer.Infrastructure.Configuration;

namespace Cataloguer.Data.DAO
{
    public class PosterDAO : BaseCrudDAO<PosterDTO>
    {
        public PosterDAO(AppConfiguration configuration) : base(configuration, configuration.PostersFileName)
        {
        }
    }
}
