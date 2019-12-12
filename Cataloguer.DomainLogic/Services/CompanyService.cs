using Cataloguer.Data.DAO;
using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.DomainLogic.Mapping;
using Cataloguer.DomainLogic.Services.BaseClasses;
using Cataloguer.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cataloguer.DomainLogic.Services
{
    public class CompanyService : BaseService, ICrudService<Company>
    {
        private readonly CompanyDAO _companyDAO;

        public CompanyService(
            AppConfiguration configuration,
            CompanyDAO companyDAO
        ) : base(configuration)
        {
            _companyDAO = companyDAO;
        }

        public int Create(Company entity)
        {
            ValidateExistingName(entity);

            return _companyDAO.Create(entity.ToDto());
        }

        public void Delete(int id)
        {
            _companyDAO.Delete(id);
        }

        public Company Get(int id)
        {
            return _companyDAO.Get(id)
                ?.ToModel();
        }

        public IEnumerable<Company> GetAll()
        {
            return _companyDAO.GetAll()
                .Select(item => item.ToModel())
                .OrderBy(item => item.Name);
        }

        public void Update(Company entity)
        {
            ValidateExistingName(entity);

            _companyDAO.Update(entity.ToDto());
        }

        private void ValidateExistingName(Company entity)
        {
            bool companyExists = _companyDAO.GetAll()
                .Any(companyDto => companyDto.Name == entity.Name);

            if (companyExists)
            {
                throw new ApplicationException($"Company with name {entity.Name} already exists.");
            }
        }
    }
}
