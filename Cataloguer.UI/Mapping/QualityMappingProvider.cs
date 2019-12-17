using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.Infrastructure.Mapping;
using Cataloguer.UI.ViewModels;

namespace Cataloguer.UI.Mapping
{
    public class QualityMappingProvider : MappingProvider<QualityViewModel, Quality>
    {
        public override Quality Map(QualityViewModel source, Mapper mapper)
        {
            return new Quality
            {
                Id = source.Id,
                Name = source.Name,
            };
        }

        public override QualityViewModel Map(Quality dest, Mapper mapper)
        {
            return new QualityViewModel
            {
                Id = dest.Id,
                Name = dest.Name,
            };
        }
    }
}
