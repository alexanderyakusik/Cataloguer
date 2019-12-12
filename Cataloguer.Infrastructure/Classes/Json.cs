using Newtonsoft.Json;

namespace Cataloguer.Infrastructure.Classes
{
    public static class Json
    {
        public static T Parse<T>(string source)
        {
            return JsonConvert.DeserializeObject<T>(source);
        }
    }
}
