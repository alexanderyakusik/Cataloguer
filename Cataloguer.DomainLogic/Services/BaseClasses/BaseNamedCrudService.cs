using Cataloguer.Data.DAO.BaseClasses;
using Cataloguer.Data.DTO.BaseClasses;
using Cataloguer.DomainLogic.Interfaces.Models.BaseClasses;
using Cataloguer.Infrastructure.Configuration;
using Cataloguer.Infrastructure.Mapping;
using System;
using System.Linq;

namespace Cataloguer.DomainLogic.Services.BaseClasses
{
    public class BaseNamedCrudService<TModel, TDto> : BaseCrudService<TModel, TDto>
        where TModel : NamedBaseModel
        where TDto : BaseDTO
    {
        protected BaseNamedCrudService(
            AppConfiguration configuration,
            Mapper mapper,
            BaseCrudDAO<TDto> dao
        ) : base(configuration, mapper, dao)
        {
        }

        public override int Create(TModel entity)
        {
            ValidateExistingName(entity);

            return base.Create(entity);
        }

        public override void Update(TModel entity)
        {
            ValidateExistingName(entity);

            base.Update(entity);
        }

        private void ValidateExistingName(TModel entity)
        {
            bool entityExists = _dao.GetAll()
                .Select(_mapper.Map<TModel>)
                .Any(item => item.Name == entity.Name);

            if (entityExists)
            {
                throw new ApplicationException($"Entity with name {entity.Name} already exists.");
            }
        }
    }
}
