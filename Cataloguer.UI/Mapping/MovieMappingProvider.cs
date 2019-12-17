using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.Infrastructure.Mapping;
using Cataloguer.UI.ViewModels;

namespace Cataloguer.UI.Mapping
{
    public class MovieMappingProvider : MappingProvider<MovieViewModel, Movie>
    {
        public override Movie Map(MovieViewModel source, Mapper mapper)
        {
            return new Movie
            {
                Id = source.Id,
                Name = source.Name,
                Runtime = source.Runtime,
                ReleaseDate = source.ReleaseDate,
                Company = mapper.Map<Company>(source.Company),
                Genre = mapper.Map<Genre>(source.Genre),
                Quality = mapper.Map<Quality>(source.Quality),
                Format = mapper.Map<Format>(source.Format),
                Poster = mapper.Map<Poster>(source.Poster),
            };
        }

        public override MovieViewModel Map(Movie dest, Mapper mapper)
        {
            return new MovieViewModel
            {
                Id = dest.Id,
                Name = dest.Name,
                Runtime = dest.Runtime,
                ReleaseDate = dest.ReleaseDate,
                Company = mapper.Map<CompanyViewModel>(dest.Company),
                Genre = mapper.Map<GenreViewModel>(dest.Genre),
                Quality = mapper.Map<QualityViewModel>(dest.Quality),
                Format = mapper.Map<FormatViewModel>(dest.Format),
                Poster = mapper.Map<PosterViewModel>(dest.Poster),
            };
        }
    }
}
