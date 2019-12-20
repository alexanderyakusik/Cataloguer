using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.DomainLogic.Interfaces.Models.Search;
using System.Collections.Generic;

namespace Cataloguer.DomainLogic.Interfaces.Services
{
    public interface IMovieService : ICrudService<Movie>
    {
        IEnumerable<Movie> Search(MovieSearchModel searchModel);
    }
}
