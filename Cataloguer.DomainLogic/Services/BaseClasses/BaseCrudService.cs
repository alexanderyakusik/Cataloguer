using Cataloguer.Data.DAO.BaseClasses;
using Cataloguer.Data.DTO.BaseClasses;
using Cataloguer.DomainLogic.Interfaces.Models.BaseClasses;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.DomainLogic.Mapping;
using Cataloguer.Infrastructure.Configuration;
using Cataloguer.Infrastructure.Mapping;
using System.Collections.Generic;

namespace Cataloguer.DomainLogic.Services.BaseClasses
{
    public class BaseCrudService<TModel, TDto> : BaseService, ICrudService<TModel>
        where TModel : BaseModel
        where TDto : BaseDTO
    {
        private readonly BaseCrudDAO<TDto> _dao;
        private readonly Mapper _mapper;

        protected BaseCrudService(
            AppConfiguration configuration,
            Mapper mapper,
            BaseCrudDAO<TDto> dao
        ) : base(configuration)
        {
            _dao = dao;
        }

        public virtual int Create(TModel entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public virtual TModel Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public virtual IEnumerable<TModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Update(TModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
