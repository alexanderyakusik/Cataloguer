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
    public class QualityService : BaseService, ICrudService<Quality>
    {
        private readonly QualityDAO _qualityDAO;

        public QualityService(
            AppConfiguration configuration,
            QualityDAO qualityDAO
        ) : base(configuration)
        {
            _qualityDAO = qualityDAO;
        }

        public int Create(Quality entity)
        {
            ValidateExistingName(entity);

            return _qualityDAO.Create(entity.ToDto());
        }

        public void Delete(int id)
        {
            _qualityDAO.Delete(id);
        }

        public Quality Get(int id)
        {
            return _qualityDAO.Get(id)
                ?.ToModel();
        }

        public IEnumerable<Quality> GetAll()
        {
            return _qualityDAO.GetAll()
                .Select(item => item.ToModel())
                .OrderBy(item => item.Name);
        }

        public void Update(Quality entity)
        {
            ValidateExistingName(entity);

            _qualityDAO.Update(entity.ToDto());
        }

        private void ValidateExistingName(Quality entity)
        {
            bool qualityExists = _qualityDAO.GetAll()
                .Any(qualityDto => qualityDto.Name == entity.Name);

            if (qualityExists)
            {
                throw new ApplicationException($"Quality with name {entity.Name} already exists.");
            }
        }
    }
}
