using Cataloguer.DomainLogic.Interfaces.Enums;
using Cataloguer.DomainLogic.Interfaces.Models.Search;
using System;

namespace Cataloguer.DomainLogic.Search
{
    public static class SearchHelper
    {
        public static Func<T, bool> ConvertComparison<T>(SearchComparison<T> comparison) where T : IComparable
        {
            if (comparison == null || comparison.Comparison == Comparison.None)
            {
                return (T obj) => true;
            }

            switch (comparison.Comparison)
            {
                case Comparison.MoreThan:
                    return (T obj) => obj.CompareTo(comparison.Object) > 0;
                case Comparison.Equal:
                    return (T obj) => obj.CompareTo(comparison.Object) == 0;
                case Comparison.LessThan:
                    return (T obj) => obj.CompareTo(comparison.Object) < 0;
                default:
                    return (T obj) => true;
            }
        }
    }
}
