using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.Infrastructure.Mapping;

namespace Cataloguer.DomainLogic.Mapping
{
    public class QualityMappingProvider : MappingProvider<Quality, QualityDTO>
    {
        public override QualityDTO Map(Quality source)
        {
            return new QualityDTO
            {
                Id = source.Id,
                Name = source.Name,
            };
        }

        public override Quality Map(QualityDTO dest)
        {
            return new Quality
            {
                Id = dest.Id,
                Name = dest.Name,
            };
        }
    }
}
