using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.UI.ViewModels.BaseClasses;
using System;

namespace Cataloguer.UI.ViewModels
{
    public class MovieViewModel : NamedBaseViewModel
    {
        public CompanyViewModel Company { get; set; }

        public DateTime ReleaseDate { get; set; }

        public GenreViewModel Genre { get; set; }

        public TimeSpan Runtime { get; set; }

        public FormatViewModel Format { get; set; }

        public QualityViewModel Quality { get; set; }

        public PosterViewModel Poster { get; set; }
    }
}
