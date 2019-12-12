using Cataloguer.Data.DAO.BaseClasses;
using Cataloguer.Data.DTO;
using Cataloguer.Infrastructure.Configuration;

namespace Cataloguer.Data.DAO
{
    public class GenreDAO : BaseCrudDAO<GenreDTO>
    {
        public GenreDAO(AppConfiguration configuration) : base(configuration, configuration.GenresFileName)
        {
        }
    }
}
