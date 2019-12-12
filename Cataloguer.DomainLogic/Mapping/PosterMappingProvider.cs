using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.Infrastructure.Mapping;

namespace Cataloguer.DomainLogic.Mapping
{
    public class PosterMappingProvider : MappingProvider<Poster, PosterDTO>
    {
        public override PosterDTO Map(Poster source)
        {
            return new PosterDTO
            {
                Id = source.Id,
            };
        }

        public override Poster Map(PosterDTO dest)
        {
            return new Poster
            {
                Id = dest.Id,
            };
        }
    }
}
