using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.Infrastructure.Mapping;

namespace Cataloguer.DomainLogic.Mapping
{
    public class MovieMappingProvider : MappingProvider<Movie, MovieDTO>
    {
        public override MovieDTO Map(Movie source, Mapper mapper)
        {
            return new MovieDTO
            {
                Id = source.Id,
                Name = source.Name,
                Runtime = source.Runtime,
                ReleaseDate = source.ReleaseDate,
                CompanyId = source.Company.Id,
                FormatId = source.Format.Id,
                GenreId = source.Genre.Id,
                PosterId = source.Poster.Id != 0 ? (int?)source.Poster.Id : null,
                QualityId = source.Quality.Id,
            };
        }

        public override Movie Map(MovieDTO dest, Mapper mapper)
        {
            return new Movie
            {
                Id = dest.Id,
                Name = dest.Name,
                Runtime = dest.Runtime,
                ReleaseDate = dest.ReleaseDate,
                Company = new Company { Id = dest.CompanyId },
                Format = new Format { Id = dest.FormatId },
                Genre = new Genre { Id = dest.GenreId },
                Quality = new Quality { Id = dest.QualityId },
                Poster = new Poster { Id = dest.PosterId ?? 0 },
            };
        }
    }
}
