using System.Collections.Generic;
using Cataloguer.Data.DAO;
using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Models;
using Cataloguer.DomainLogic.Services.BaseClasses;
using Cataloguer.DomainLogic.Services.Interfaces;
using Cataloguer.Infrastructure.Configuration;

namespace Cataloguer.DomainLogic.Services
{
    public class PosterService : BaseService, ICrudService<Poster>
    {
        private readonly PosterImageDAO _posterImageDAO;
        private readonly PosterDAO _posterDAO;

        public PosterService(
            AppConfiguration configuration,
            PosterDAO posterDAO,
            PosterImageDAO posterImageDAO
        ) : base(configuration)
        {
            _posterImageDAO = posterImageDAO;
            _posterDAO = posterDAO;
        }

        public int Create(Poster entity)
        {
            string fileName = _posterDAO.GetNextId().ToString();

            _posterImageDAO.Create(entity.Image, fileName);
            int id = _posterDAO.Create(new PosterDTO { FileName = fileName });

            return id;
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Poster Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Poster> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Poster entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
