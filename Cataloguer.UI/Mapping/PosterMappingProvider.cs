using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.Infrastructure.Mapping;
using Cataloguer.UI.ViewModels;

namespace Cataloguer.UI.Mapping
{
    public class PosterMappingProvider : MappingProvider<PosterViewModel, Poster>
    {
        public override Poster Map(PosterViewModel source, Mapper mapper)
        {
            return new Poster
            {
                Id = source.Id,
                Image = source.Image,
            };
        }

        public override PosterViewModel Map(Poster dest, Mapper mapper)
        {
            return new PosterViewModel
            {
                Id = dest.Id,
                Image = dest.Image,
            };
        }
    }
}
