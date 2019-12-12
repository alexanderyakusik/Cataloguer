using System;
using System.Collections.Generic;
using System.Linq;
using Cataloguer.Data.DAO;
using Cataloguer.DomainLogic.Mapping;
using Cataloguer.DomainLogic.Models;
using Cataloguer.DomainLogic.Services.BaseClasses;
using Cataloguer.DomainLogic.Services.Interfaces;
using Cataloguer.Infrastructure.Configuration;

namespace Cataloguer.DomainLogic.Services
{
    public class GenreService : BaseService, ICrudService<Genre>
    {
        private readonly GenreDAO _genreDAO;

        public GenreService(
            AppConfiguration configuration,
            GenreDAO genreDAO
        ) : base(configuration)
        {
            _genreDAO = genreDAO;
        }

        public int Create(Genre entity)
        {
            ValidateExistingName(entity);

            return _genreDAO.Create(entity.ToDto());
        }

        public void Delete(int id)
        {
            _genreDAO.Delete(id);
        }

        public Genre Get(int id)
        {
            return _genreDAO.Get(id)
                ?.ToModel();
        }

        public IEnumerable<Genre> GetAll()
        {
            return _genreDAO.GetAll()
                .Select(item => item.ToModel())
                .OrderBy(item => item.Name);
        }

        public void Update(Genre entity)
        {
            ValidateExistingName(entity);

            _genreDAO.Update(entity.ToDto());
        }

        private void ValidateExistingName(Genre entity)
        {
            bool genreExists = _genreDAO.GetAll()
                .Any(genreDto => genreDto.Name == entity.Name);

            if (genreExists)
            {
                throw new ApplicationException($"Genre with name {entity.Name} already exists.");
            }
        }
    }
}
