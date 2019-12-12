using Cataloguer.Data.DAO.BaseClasses;
using Cataloguer.Infrastructure.Configuration;
using System.IO;

namespace Cataloguer.Data.DAO
{
    public class PosterImageDAO : BaseDAO
    {
        public PosterImageDAO(AppConfiguration configuration) : base(configuration)
        {
        }

        public void Create(byte[] bytes, string fileName)
        {
            string path = GetImagePath(fileName);

            File.WriteAllBytes(path, bytes);
        }

        public byte[] Get(string fileName)
        {
            string path = GetImagePath(fileName);

            if (!File.Exists(path))
            {
                return null;
            }

            return File.ReadAllBytes(path);
        }

        public void Update(byte[] bytes, string fileName)
        {
            string path = GetImagePath(fileName);

            if (!File.Exists(path))
            {
                return;
            }

            File.WriteAllBytes(path, bytes);
        }

        public void Delete(string fileName)
        {
            string path = GetImagePath(fileName);

            if (!File.Exists(path))
            {
                return;
            }

            File.Delete(path);
        }

        private string GetImagePath(string fileName)
        {
            return Path.Combine(Configuration.ImagesPath, fileName);
        }
    }
}
