using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.Infrastructure.Mapping;

namespace Cataloguer.DomainLogic.Mapping
{
    public class GenreMappingProvider : MappingProvider<Genre, GenreDTO>
    {
        public override GenreDTO Map(Genre source, Mapper mapper)
        {
            return new GenreDTO
            {
                Id = source.Id,
                Name = source.Name,
            };
        }

        public override Genre Map(GenreDTO dest, Mapper mapper)
        {
            return new Genre
            {
                Id = dest.Id,
                Name = dest.Name,
            };
        }
    }
}
