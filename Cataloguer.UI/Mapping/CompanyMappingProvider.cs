using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.Infrastructure.Mapping;
using Cataloguer.UI.ViewModels;

namespace Cataloguer.UI.Mapping
{
    public class CompanyMappingProvider : MappingProvider<CompanyViewModel, Company>
    {
        public override Company Map(CompanyViewModel source)
        {
            return new Company
            {
                Id = source.Id,
                Name = source.Name,
            };
        }

        public override CompanyViewModel Map(Company dest)
        {
            return new CompanyViewModel
            {
                Id = dest.Id,
                Name = dest.Name,
            };
        }
    }
}
