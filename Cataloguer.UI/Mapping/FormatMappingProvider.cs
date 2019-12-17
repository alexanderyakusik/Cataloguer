using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.Infrastructure.Mapping;
using Cataloguer.UI.ViewModels;

namespace Cataloguer.UI.Mapping
{
    public class FormatMappingProvider : MappingProvider<FormatViewModel, Format>
    {
        public override Format Map(FormatViewModel source, Mapper mapper)
        {
            return new Format
            {
                Id = source.Id,
                Name = source.Name,
            };
        }

        public override FormatViewModel Map(Format dest, Mapper mapper)
        {
            return new FormatViewModel
            {
                Id = dest.Id,
                Name = dest.Name,
            };
        }
    }
}
