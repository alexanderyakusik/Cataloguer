using Newtonsoft.Json;

namespace Cataloguer.Infrastructure.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object @object)
        {
            return JsonConvert.SerializeObject(@object);
        }
    }
}
