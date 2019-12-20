using Cataloguer.DomainLogic.Interfaces.Enums;

namespace Cataloguer.DomainLogic.Interfaces.Models.Search
{
    public class SearchComparison<T>
    {
        public Comparison Comparison { get; set; }

        public T Object { get; set; }
    }
}
