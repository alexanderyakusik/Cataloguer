using Cataloguer.Data.DAO.BaseClasses;
using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.DomainLogic.Services.BaseClasses;
using Cataloguer.Infrastructure.Configuration;
using Cataloguer.Infrastructure.Mapping;

namespace Cataloguer.DomainLogic.Services
{
    public class MovieService : BaseNamedCrudService<Movie, MovieDTO>, IMovieService
    {
        public MovieService(AppConfiguration configuration, Mapper mapper, BaseCrudDAO<MovieDTO> dao) : base(configuration, mapper, dao)
        {
        }
    }
}
