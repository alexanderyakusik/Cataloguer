using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.Infrastructure.Mapping;

namespace Cataloguer.DomainLogic.Mapping
{
    public class CompanyMappingProvider : MappingProvider<Company, CompanyDTO>
    {
        public override CompanyDTO Map(Company source)
        {
            return new CompanyDTO
            {
                Id = source.Id,
                Name = source.Name,
            };
        }

        public override Company Map(CompanyDTO dest)
        {
            return new Company
            {
                Id = dest.Id,
                Name = dest.Name,
            };
        }
    }
}
