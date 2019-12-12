using System;
using System.Configuration;
using System.Reflection;

namespace Cataloguer.Infrastructure.Configuration
{
    public class AppConfiguration
    {
        private object Read(string key, Type returnType)
        {
            string value = ConfigurationManager.AppSettings[key]
                ?? throw new ApplicationException($"Unable to read {key} from the settings. The value is missing.");

            return Convert.ChangeType(value, returnType);
        }

        public string ImagesPath { get; private set; }

        public string DataPath { get; private set; }

        public string PostersFileName { get; private set; }

        public string MoviesFileName { get; private set; }

        public string GenresFileName { get; private set; }

        public string QualitiesFileName { get; private set; }

        public string CompaniesFileName { get; private set; }

        public string FormatsFileName { get; private set; }

        public AppConfiguration()
        {
            PropertyInfo[] propertyInfos = typeof(AppConfiguration)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                object value = Read(propertyInfo.Name, propertyInfo.PropertyType);
                propertyInfo.SetValue(this, value);
            }
        }
    }
}
