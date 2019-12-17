using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.Infrastructure.Mapping;

namespace Cataloguer.DomainLogic.Mapping
{
    public class CompanyMappingProvider : MappingProvider<Company, CompanyDTO>
    {
        public override CompanyDTO Map(Company source, Mapper mapper)
        {
            return new CompanyDTO
            {
                Id = source.Id,
                Name = source.Name,
            };
        }

        public override Company Map(CompanyDTO dest, Mapper mapper)
        {
            return new Company
            {
                Id = dest.Id,
                Name = dest.Name,
            };
        }
    }
}
