using Cataloguer.Data.DAO;
using Cataloguer.Data.DAO.BaseClasses;
using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Interfaces.Exceptions;
using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.DomainLogic.Interfaces.Models.BaseClasses;
using Cataloguer.DomainLogic.Interfaces.Models.Search;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.DomainLogic.Services.BaseClasses;
using Cataloguer.Infrastructure.Configuration;
using Cataloguer.Infrastructure.Mapping;
using System;
using Cataloguer.DomainLogic.Search;
using System.Collections.Generic;
using System.Linq;

namespace Cataloguer.DomainLogic.Services
{
    public class MovieService : BaseNamedCrudService<Movie, MovieDTO>, IMovieService
    {
        private readonly PosterService _posterService;

        public MovieService(
            AppConfiguration configuration,
            DAOStorage daoStorage,
            Mapper mapper,
            BaseCrudDAO<MovieDTO> dao,
            PosterService posterService
        ) : base(configuration, daoStorage, mapper, dao)
        {
            _posterService = posterService;
        }

        public override Movie Get(int id)
        {
            MovieDTO movieDto = DAO.Get(id);
            if (movieDto == null)
            {
                return null;
            }

            return GetMovie(movieDto);
        }

        public override IEnumerable<Movie> GetAll()
        {
            return DAO.GetAll()
                .Select(GetMovie)
                .OrderBy(movie => movie.Id);
        }

        public override void Delete(int id)
        {
            MovieDTO movieDto = DAO.Get(id);
            if (movieDto == null)
            {
                return;
            }

            if (movieDto.PosterId.HasValue)
            {
                _posterService.Delete(movieDto.PosterId.Value);
            }
            base.Delete(id);
        }

        public override int Create(Movie entity)
        {
            Validate(entity);
            if (entity.Poster.Id != 0)
            {
                entity.Poster.Id = _posterService.Create(entity.Poster);
            }
            int id = CreateCore(entity);

            return id;
        }

        public override void Update(Movie entity)
        {
            ValidateMovie(entity);
            if (entity.Poster.Image != null)
            {
                if (entity.Poster.Id == 0)
                {
                    entity.Poster.Id = _posterService.Create(entity.Poster);
                }
                else
                {
                    _posterService.Update(entity.Poster);
                }
            }
            UpdateCore(entity);
        }

        protected override void Validate(Movie entity)
        {
            ValidateMovie(entity);
            base.Validate(entity);
        }

        private Movie GetMovie(MovieDTO movieDto)
        {
            var movie = Mapper.Map<Movie>(movieDto);
            movie.Company.Name = Storage.CompanyDAO.Get(movie.Company.Id)?.Name ?? throw new ApplicationException($"Company with id {movie.Company.Id} doesn't exist.");
            movie.Genre.Name = Storage.GenreDAO.Get(movie.Genre.Id)?.Name ?? throw new ApplicationException($"Genre with id {movie.Genre.Id} doesn't exist.");
            movie.Quality.Name = Storage.QualityDAO.Get(movie.Quality.Id)?.Name ?? throw new ApplicationException($"Quality with id {movie.Quality.Id} doesn't exist.");
            movie.Format.Name = Storage.FormatDAO.Get(movie.Format.Id)?.Name ?? throw new ApplicationException($"Format with id {movie.Format.Id} doesn't exist.");

            if (movie.Poster.Id != 0)
            {
                movie.Poster.Image = _posterService.Get(movie.Poster.Id)?.Image ?? throw new ApplicationException($"Poster with id {movie.Poster.Id} doesn't exist.");
            }

            return movie;
        }

        private void ValidateMovie(Movie movie)
        {
            ValidateId(movie.Genre, "Жанр");
            ValidateId(movie.Company, "Компания");
            ValidateId(movie.Quality, "Качество");
            ValidateId(movie.Format, "Формат");
        }

        private void ValidateId(BaseModel model, string modelName)
        {
            if (model.Id == 0)
            {
                throw new ValidationException($"Необходимо назначить объект типа {modelName}.");
            }
        }

        public IEnumerable<Movie> Search(MovieSearchModel searchModel)
        {
            return GetAll()
                .Where(item =>
                    StartsWith(item.Name, searchModel.Name) &&
                    Equal(item.Company.Name, searchModel.CompanyName) &&
                    Equal(item.Genre.Name, searchModel.GenreName) &&
                    Equal(item.Quality.Name, searchModel.QualityName) &&
                    Equal(item.Format.Name, searchModel.FormatName) &&
                    IsComparisonCorrect(item.Runtime, searchModel.RuntimeComparison) &&
                    IsComparisonCorrect(item.ReleaseDate, searchModel.ReleaseDateComparison)
                );
        }

        private bool Equal(string source, string compared)
        {
            return string.IsNullOrWhiteSpace(compared) || source == compared;
        }

        private bool StartsWith(string source, string starts)
        {
            return string.IsNullOrWhiteSpace(starts) || source.StartsWith(starts);
        }
        
        private bool IsComparisonCorrect<T>(T source, SearchComparison<T> comparison) where T : IComparable
        {
            return SearchHelper.ConvertComparison(comparison).Invoke(source);
        }
    }
}
