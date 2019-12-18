using Cataloguer.Data.DAO;
using Cataloguer.Data.DAO.BaseClasses;
using Cataloguer.Data.DTO;
using Cataloguer.DomainLogic.Interfaces.Exceptions;
using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.DomainLogic.Interfaces.Models.BaseClasses;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.DomainLogic.Services.BaseClasses;
using Cataloguer.Infrastructure.Configuration;
using Cataloguer.Infrastructure.Mapping;
using System;
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
                .Select(GetMovie);
        }

        public override void Delete(int id)
        {
            MovieDTO movieDto = DAO.Get(id);
            if (movieDto == null)
            {
                return;
            }

            _posterService.Delete(movieDto.PosterId);
            base.Delete(id);
        }

        public override int Create(Movie entity)
        {
            Validate(entity);
            entity.Poster.Id = _posterService.Create(entity.Poster);
            int id = CreateCore(entity);

            return id;
        }

        public override void Update(Movie entity)
        {
            ValidateMovie(entity);
            _posterService.Update(entity.Poster);
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

            movie.Poster.Image = _posterService.Get(movie.Poster.Id)?.Image ?? throw new ApplicationException($"Poster with id {movie.Poster.Id} doesn't exist.");

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
    }
}
