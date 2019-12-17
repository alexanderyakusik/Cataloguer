using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.Infrastructure.Mapping;
using Cataloguer.UI.ViewModels;

namespace Cataloguer.UI.Mapping
{
    public class GenreMappingProvider : MappingProvider<GenreViewModel, Genre>
    {
        public override Genre Map(GenreViewModel source)
        {
            return new Genre
            {
                Id = source.Id,
                Name = source.Name,
            };
        }

        public override GenreViewModel Map(Genre dest)
        {
            return new GenreViewModel
            {
                Id = dest.Id,
                Name = dest.Name,
            };
        }
    }
}
