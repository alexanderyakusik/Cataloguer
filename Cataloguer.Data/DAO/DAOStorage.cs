namespace Cataloguer.Data.DAO
{
    public class DAOStorage
    {
        public CompanyDAO CompanyDAO { get; }

        public FormatDAO FormatDAO { get; }

        public GenreDAO GenreDAO { get; }

        public PosterDAO PosterDAO { get; }

        public QualityDAO QualityDAO { get; }

        public MovieDAO MovieDAO { get; }

        public PosterImageDAO PosterImageDAO { get; }

        public DAOStorage(
            CompanyDAO companyDAO,
            FormatDAO formatDAO,
            GenreDAO genreDAO,
            PosterDAO posterDAO,
            QualityDAO qualityDAO,
            MovieDAO movieDAO,
            PosterImageDAO posterImageDAO
        )
        {
            CompanyDAO = companyDAO;
            FormatDAO = formatDAO;
            GenreDAO = genreDAO;
            PosterDAO = posterDAO;
            QualityDAO = qualityDAO;
            MovieDAO = movieDAO;
            PosterImageDAO = posterImageDAO;
        }
    }
}
