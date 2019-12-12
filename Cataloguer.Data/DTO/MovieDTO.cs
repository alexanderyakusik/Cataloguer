using Cataloguer.Data.DTO.BaseClasses;
using System;

namespace Cataloguer.Data.DTO
{
    public class MovieDTO : NamedBaseDTO
    {
        public int CompanyId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int GenreId { get; set; }

        public TimeSpan Runtime { get; set; }

        public int FormatId { get; set; }

        public int QualityId { get; set; }

        public int PosterId { get; set; }
    }
}
