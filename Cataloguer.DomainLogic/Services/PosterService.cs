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
        private readonly PosterImageDAO _posterImageDAO;

        public PosterService(
            AppConfiguration configuration,
            Mapper mapper,
            BaseCrudDAO<PosterDTO> dao,
            PosterImageDAO posterImageDAO
        ) : base(configuration, mapper, dao)
        {
            _posterImageDAO = posterImageDAO;
        }

        public override int Create(Poster entity)
        {
            string fileName = DAO.GetNextId().ToString();
            _posterImageDAO.Create(entity.Image, fileName);

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

            byte[] image = _posterImageDAO.Get(fileName);
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

            _posterImageDAO.Update(entity.Image, fileName);
        }

        public override void Delete(int id)
        {
            string fileName = DAO.Get(id)?.FileName;
            if (fileName == null)
            {
                return;
            }

            _posterImageDAO.Delete(fileName);
            DAO.Delete(id);
        }
    }
}
