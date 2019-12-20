using System;

namespace Cataloguer.DomainLogic.Interfaces.Models.Search
{
    public class MovieSearchModel
    {
        public string Name { get; set; }

        public string CompanyName { get; set; }

        public string GenreName { get; set; }

        public string QualityName { get; set; }

        public string FormatName { get; set; }

        public SearchComparison<TimeSpan> RuntimeComparison { get; set; }

        public SearchComparison<DateTime> ReleaseDateComparison { get; set; }
    }
}
