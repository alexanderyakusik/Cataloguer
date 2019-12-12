using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Models;

namespace Cataloguer.DomainLogic.Mapping
{
    public static class MovieMappingExtensions
    {
        public static MovieDTO ToDto(this Movie movie)
        {
            return new MovieDTO()
            {
                Id = movie.Id,
                Name = movie.Name,
                CompanyId = movie.Company.Id,
                FormatId = movie.Format.Id,
                GenreId = movie.Genre.Id,
                PosterId = movie.Poster.Id,
                QualityId = movie.Quality.Id,
                ReleaseDate = movie.ReleaseDate,
                Runtime = movie.Runtime,
            };
        }

        public static Movie ToModel(this MovieDTO movieDto)
        {
            return new Movie()
            {
                Id = movieDto.Id,
                Name = movieDto.Name,
                Runtime = movieDto.Runtime,
                ReleaseDate = movieDto.ReleaseDate,
                Company = new Company { Id = movieDto.CompanyId },
                Quality = new Quality { Id = movieDto.QualityId },
                Format = new Format { Id = movieDto.FormatId },
                Genre = new Genre { Id = movieDto.GenreId },
                Poster = new Poster { Id = movieDto.PosterId },
            };
        }
    }
}
