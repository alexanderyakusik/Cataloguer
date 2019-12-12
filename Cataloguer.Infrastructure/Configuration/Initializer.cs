using System.IO;

namespace Cataloguer.Infrastructure.Configuration
{
    public class Initializer
    {
        private AppConfiguration _config;

        public Initializer(AppConfiguration configuration)
        {
            _config = configuration;
        }

        public void Run()
        {
            PrepareDirectories(_config.DataPath, _config.ImagesPath);
            PrepareFiles(_config.DataPath,
                _config.PostersFileName,
                _config.CompaniesFileName,
                _config.QualitiesFileName,
                _config.GenresFileName,
                _config.MoviesFileName,
                _config.FormatsFileName
            );
        }

        private void PrepareDirectories(params string[] directoryPaths)
        {
            foreach (string directoryPath in directoryPaths)
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        private void PrepareFiles(string directoryPath, params string[] fileNames)
        {
            foreach (string fileName in fileNames)
            {
                string filePath = Path.Combine(directoryPath, fileName);

                if (!File.Exists(filePath))
                {
                    FileStream fileStream = File.Create(filePath);
                    fileStream.Dispose();
                }
            }
        }
    }
}
