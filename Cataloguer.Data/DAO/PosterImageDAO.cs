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
            string path = Path.Combine(Configuration.ImagesPath, fileName);

            File.WriteAllBytes(path, bytes);
        }
    }
}
