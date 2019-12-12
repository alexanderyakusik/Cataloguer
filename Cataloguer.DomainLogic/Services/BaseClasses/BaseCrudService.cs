using Cataloguer.Data.DAO.BaseClasses;
using Cataloguer.Data.DTO.BaseClasses;
using Cataloguer.DomainLogic.Interfaces.Models.BaseClasses;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.Infrastructure.Configuration;
using Cataloguer.Infrastructure.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace Cataloguer.DomainLogic.Services.BaseClasses
{
    public class BaseCrudService<TModel, TDto> : BaseService, ICrudService<TModel>
        where TModel : BaseModel
        where TDto : BaseDTO
    {
        protected readonly BaseCrudDAO<TDto> _dao;
        protected readonly Mapper _mapper;

        protected BaseCrudService(
            AppConfiguration configuration,
            Mapper mapper,
            BaseCrudDAO<TDto> dao
        ) : base(configuration)
        {
            _dao = dao;
            _mapper = mapper;
        }

        public virtual int Create(TModel entity)
        {
            return _dao.Create(_mapper.Map<TDto>(entity));
        }

        public virtual void Delete(int id)
        {
            _dao.Delete(id);
        }

        public virtual TModel Get(int id)
        {
            return _mapper.Map<TModel>(_dao.Get(id));
        }

        public virtual IEnumerable<TModel> GetAll()
        {
            return _dao.GetAll()
                .Select(_mapper.Map<TModel>);
        }

        public virtual void Update(TModel entity)
        {
            _dao.Update(_mapper.Map<TDto>(entity));
        }
    }
}
