using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.Infrastructure.Mapping;
using Cataloguer.UI.ViewModels;

namespace Cataloguer.UI.Mapping
{
    public class CompanyMappingProvider : MappingProvider<CompanyViewModel, Company>
    {
        public override Company Map(CompanyViewModel source, Mapper mapper)
        {
            return new Company
            {
                Id = source.Id,
                Name = source.Name,
            };
        }

        public override CompanyViewModel Map(Company dest, Mapper mapper)
        {
            return new CompanyViewModel
            {
                Id = dest.Id,
                Name = dest.Name,
            };
        }
    }
}
