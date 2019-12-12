using Cataloguer.Data.DAO.BaseClasses;
using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.DomainLogic.Services.BaseClasses;
using Cataloguer.Infrastructure.Configuration;
using Cataloguer.Infrastructure.Mapping;

namespace Cataloguer.DomainLogic.Services
{
    public class GenreService : BaseNamedCrudService<Genre, GenreDTO>, IGenreService
    {
        public GenreService(AppConfiguration configuration, Mapper mapper, BaseCrudDAO<GenreDTO> dao) : base(configuration, mapper, dao)
        {
        }
    }
}
