using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.Infrastructure.Mapping;

namespace Cataloguer.DomainLogic.Mapping
{
    public class GenreMappingProvider : MappingProvider<Genre, GenreDTO>
    {
        public override GenreDTO Map(Genre source)
        {
            return new GenreDTO
            {
                Id = source.Id,
                Name = source.Name,
            };
        }

        public override Genre Map(GenreDTO dest)
        {
            return new Genre
            {
                Id = dest.Id,
                Name = dest.Name,
            };
        }
    }
}
