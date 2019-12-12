using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Models;

namespace Cataloguer.DomainLogic.Mapping
{
    public static class QualityMappingExtensions
    {
        public static QualityDTO ToDto(this Quality quality)
        {
            return new QualityDTO()
            {
                Id = quality.Id,
                Name = quality.Name,
            };
        }

        public static Quality ToModel(this QualityDTO qualityDto)
        {
            return new Quality()
            {
                Id = qualityDto.Id,
                Name = qualityDto.Name,
            };
        }
    }
}
