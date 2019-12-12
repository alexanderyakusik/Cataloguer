using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Models;

namespace Cataloguer.DomainLogic.Mapping
{
    public static class CompanyMappingExtensions
    {
        public static CompanyDTO ToDto(this Company company)
        {
            return new CompanyDTO
            {
                Id = company.Id,
                Name = company.Name,
            };
        }

        public static Company ToModel(this CompanyDTO companyDto)
        {
            return new Company
            {
                Id = companyDto.Id,
                Name = companyDto.Name,
            };
        }
    }
}
