using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Models;

namespace Cataloguer.DomainLogic.Mapping
{
    public static class GenreMappingExtensions
    {
        public static GenreDTO ToDto(this Genre genre)
        {
            return new GenreDTO()
            {
                Id = genre.Id,
                Name = genre.Name,
            };
        }

        public static Genre ToModel(this GenreDTO genreDto)
        {
            return new Genre()
            {
                Id = genreDto.Id,
                Name = genreDto.Name,
            };
        }
    }
}
