using Cataloguer.Data.DAO;
using Cataloguer.DomainLogic.Models;
using Cataloguer.DomainLogic.Services.BaseClasses;
using Cataloguer.DomainLogic.Services.Interfaces;
using Cataloguer.Infrastructure.Configuration;
using System.Collections.Generic;

namespace Cataloguer.DomainLogic.Services
{
    public class MovieService : BaseService, ICrudService<Movie>
    {
        private readonly PosterService _posterService;

        public MovieService(
            AppConfiguration configuration,
            MovieDAO movieDAO,
            PosterService posterService
        ) : base(configuration)
        {
            _posterService = posterService;
        }

        public int Create(Movie entity)
        {
            _posterService.Create(entity.Poster);

            return 0;
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Movie Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Movie> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Movie entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
