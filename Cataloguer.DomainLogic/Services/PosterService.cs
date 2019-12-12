using System;
using System.Collections.Generic;
using Cataloguer.Data.DAO;
using Cataloguer.Data.DAO.BaseClasses;
using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.DomainLogic.Services.BaseClasses;
using Cataloguer.Infrastructure.Configuration;
using Cataloguer.Infrastructure.Mapping;

namespace Cataloguer.DomainLogic.Services
{
    public class PosterService : BaseCrudService<Poster, PosterDTO>, IPosterService
    {
        public PosterService(
            AppConfiguration configuration,
            DAOStorage daoStorage,
            Mapper mapper,
            BaseCrudDAO<PosterDTO> dao
        ) : base(configuration, daoStorage, mapper, dao)
        {
        }

        public override int Create(Poster entity)
        {
            string fileName = DAO.GetNextId().ToString();
            Storage.PosterImageDAO.Create(entity.Image, fileName);

            var posterDto = Mapper.Map<PosterDTO>(entity);
            posterDto.FileName = fileName;

            return DAO.Create(posterDto);
        }

        public override Poster Get(int id)
        {
            string fileName = DAO.Get(id)?.FileName;
            if (fileName == null)
            {
                return null;
            }

            byte[] image = Storage.PosterImageDAO.Get(fileName);
            if (image == null)
            {
                return null;
            }

            return new Poster
            {
                Id = id,
                Image = image,
            };
        }

        public override void Update(Poster entity)
        {
            string fileName = DAO.Get(entity.Id)?.FileName;
            if (fileName == null)
            {
                return;
            }

            Storage.PosterImageDAO.Update(entity.Image, fileName);
        }

        public override void Delete(int id)
        {
            string fileName = DAO.Get(id)?.FileName;
            if (fileName == null)
            {
                return;
            }

            Storage.PosterImageDAO.Delete(fileName);
            DAO.Delete(id);
        }

        public override IEnumerable<Poster> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
