using Cataloguer.DomainLogic.Interfaces.Models.BaseClasses;
using System.Collections.Generic;

namespace Cataloguer.DomainLogic.Interfaces.Services
{
    public interface ICrudService<T> where T : BaseModel
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        int Create(T entity);

        void Update(T entity);

        void Delete(int id);
    }
}