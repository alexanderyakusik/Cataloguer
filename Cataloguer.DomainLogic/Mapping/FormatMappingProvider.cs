using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.Infrastructure.Mapping;

namespace Cataloguer.DomainLogic.Mapping
{
    public class FormatMappingProvider : MappingProvider<Format, FormatDTO>
    {
        public override FormatDTO Map(Format source)
        {
            return new FormatDTO
            {
                Id = source.Id,
                Name = source.Name,
            };
        }

        public override Format Map(FormatDTO dest)
        {
            return new Format
            {
                Id = dest.Id,
                Name = dest.Name,
            };
        }
    }
}
