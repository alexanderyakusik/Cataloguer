using Cataloguer.DomainLogic.Interfaces.Enums;

namespace Cataloguer.UI.FormControls.Search
{
    public class ComparisonItem
    {
        public Comparison Comparison { get; set; }

        public string Display { get; set; }

        public override string ToString()
        {
            return Display;
        }
    }
}
