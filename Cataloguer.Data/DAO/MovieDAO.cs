using Cataloguer.Data.DAO.BaseClasses;
using Cataloguer.Data.DTO;
using Cataloguer.Infrastructure.Configuration;

namespace Cataloguer.Data.DAO
{
    public class MovieDAO : BaseCrudDAO<MovieDTO>
    {
        public MovieDAO(AppConfiguration configuration) : base(configuration, configuration.MoviesFileName)
        {
        }
    }
}
