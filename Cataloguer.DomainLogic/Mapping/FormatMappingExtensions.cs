using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Models;

namespace Cataloguer.DomainLogic.Mapping
{
    public static class FormatMappingExtensions
    {
        public static FormatDTO ToDto(this Format format)
        {
            return new FormatDTO()
            {
                Id = format.Id,
                Name = format.Name,
            };
        }

        public static Format ToModel(this FormatDTO formatDto)
        {
            return new Format()
            {
                Id = formatDto.Id,
                Name = formatDto.Name,
            };
        }
    }
}
