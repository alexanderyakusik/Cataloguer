using Cataloguer.Data.DAO;
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
        protected BaseCrudDAO<TDto> DAO { get; }

        protected Mapper Mapper { get; }

        protected BaseCrudService(
            AppConfiguration configuration,
            DAOStorage daoStorage,
            Mapper mapper,
            BaseCrudDAO<TDto> dao
        ) : base(configuration, daoStorage)
        {
            DAO = dao;
            Mapper = mapper;
        }

        public virtual int Create(TModel entity)
        {
            return DAO.Create(Mapper.Map<TDto>(entity));
        }

        public virtual void Delete(int id)
        {
            DAO.Delete(id);
        }

        public virtual TModel Get(int id)
        {
            return Mapper.Map<TModel>(DAO.Get(id));
        }

        public virtual IEnumerable<TModel> GetAll()
        {
            return DAO.GetAll()
                .Select(Mapper.Map<TModel>)
                .OrderBy(item => item.Id);
        }

        public virtual void Update(TModel entity)
        {
            DAO.Update(Mapper.Map<TDto>(entity));
        }
    }
}
