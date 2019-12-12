using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Models;

namespace Cataloguer.DomainLogic.Mapping
{
    public static class PosterMappingExtensions
    {
        public static PosterDTO ToDto(this Poster poster)
        {
            return new PosterDTO()
            {
                Id = poster.Id,
            };
        }

        public static Poster ToModel(this PosterDTO posterDto)
        {
            return new Poster()
            {
                Id = posterDto.Id,
            };
        }
    }
}
