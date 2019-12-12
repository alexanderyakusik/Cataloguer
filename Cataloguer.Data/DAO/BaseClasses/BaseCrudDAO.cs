using Cataloguer.Data.DAO.Interfaces;
using Cataloguer.Data.DTO.BaseClasses;
using Cataloguer.Infrastructure.Classes;
using Cataloguer.Infrastructure.Configuration;
using Cataloguer.Infrastructure.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cataloguer.Data.DAO.BaseClasses
{
    public class BaseCrudDAO<T> : BaseDAO, IIdProvider where T : BaseDTO
    {
        private readonly string _filePath;

        protected BaseCrudDAO(AppConfiguration configuration, string fileName) : base(configuration)
        {
            _filePath = Path.Combine(Configuration.DataPath, fileName);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return ReadAllFromFile();
        }

        public virtual T Get(int id)
        {
            return ReadAllFromFile()
                .FirstOrDefault(item => item.Id == id);
        }

        public virtual int Create(T entity)
        {
            List<T> entities = ReadAllFromFile();

            entity.Id = GetNextIdBase(entities);

            entities.Add(entity);
            SaveToFile(entities);

            return entity.Id;
        }

        public virtual void Update(T entity)
        {
            List<T> entities = ReadAllFromFile();

            if (!entities.Any(item => item.Id == entity.Id))
            {
                return;
            }

            entities.RemoveAll(item => item.Id == entity.Id);
            entities.Add(entity);

            SaveToFile(entities);
        }

        public virtual void Delete(int id)
        {
            List<T> entities = ReadAllFromFile();

            SaveToFile(entities.Where(item => item.Id != id));
        }

        public virtual int GetNextId()
        {
            List<T> entities = ReadAllFromFile();

            return GetNextIdBase(entities);
        }

        private int GetNextIdBase(List<T> entities)
        {
            if (!entities.Any())
            {
                return 1;
            }

            return entities.Max(entity => entity.Id) + 1;
        }

        private List<T> ReadAllFromFile()
        {
            string contents = File.ReadAllText(_filePath);

            return Json.Parse<List<T>>(contents) ?? new List<T>();
        }

        private void SaveToFile(IEnumerable<T> entities)
        {
            string json = entities.ToJson();

            File.WriteAllText(_filePath, json);
        }
    }
}
