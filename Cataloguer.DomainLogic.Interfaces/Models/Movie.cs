using Cataloguer.DomainLogic.Interfaces.Models.BaseClasses;
using System;

namespace Cataloguer.DomainLogic.Interfaces.Models
{
    public class Movie : NamedBaseModel
    {
        public Company Company { get; set; }

        public DateTime ReleaseDate { get; set; }

        public Genre Genre { get; set; }

        public TimeSpan Runtime { get; set; }

        public Format Format { get; set; }

        public Quality Quality { get; set; }

        public Poster Poster { get; set; }
    }
}
