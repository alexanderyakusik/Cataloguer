using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.Infrastructure.Mapping;

namespace Cataloguer.DomainLogic.Mapping
{
    public class FormatMappingProvider : MappingProvider<Format, FormatDTO>
    {
        public override FormatDTO Map(Format source, Mapper mapper)
        {
            return new FormatDTO
            {
                Id = source.Id,
                Name = source.Name,
            };
        }

        public override Format Map(FormatDTO dest, Mapper mapper)
        {
            return new Format
            {
                Id = dest.Id,
                Name = dest.Name,
            };
        }
    }
}
