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
    public class FormatService : BaseService, ICrudService<Format>
    {
        private readonly FormatDAO _formatDAO;

        public FormatService(
            AppConfiguration configuration,
            FormatDAO formatDAO
        ) : base(configuration)
        {
            _formatDAO = formatDAO;
        }

        public int Create(Format entity)
        {
            ValidateExistingName(entity);

            return _formatDAO.Create(entity.ToDto());
        }

        public void Delete(int id)
        {
            _formatDAO.Delete(id);
        }

        public Format Get(int id)
        {
            return _formatDAO.Get(id)
                ?.ToModel();
        }

        public IEnumerable<Format> GetAll()
        {
            return _formatDAO.GetAll()
                .Select(item => item.ToModel())
                .OrderBy(item => item.Name);
        }

        public void Update(Format entity)
        {
            ValidateExistingName(entity);

            _formatDAO.Update(entity.ToDto());
        }

        private void ValidateExistingName(Format entity)
        {
            bool formatExists = _formatDAO.GetAll()
                .Any(formatDto => formatDto.Name == entity.Name);

            if (formatExists)
            {
                throw new ApplicationException($"Format with name {entity.Name} already exists.");
            }
        }
    }
}
