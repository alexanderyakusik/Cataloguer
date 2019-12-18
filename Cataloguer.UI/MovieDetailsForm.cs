using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.UI.Extensions;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Cataloguer.UI
{
    public partial class MovieDetailsForm : Form
    {
        public MovieDetailsForm(int id, IMovieService service)
        {
            InitializeComponent();

            InitializeView(service.Get(id));
        }

        private void InitializeView(Movie movie)
        {
            SetText(labelName, movie.Name);
            SetText(labelGenre, movie.Genre.Name);
            SetText(labelReleaseDate, movie.ReleaseDate.ToLocaleDate());
            SetText(labelRuntime, movie.Runtime.ToShortForm());
            SetText(labelCompany, movie.Company.Name);
            SetText(labelQuality, movie.Quality.Name);
            SetText(labelFormat, movie.Format.Name);

            SetPoster(movie);
        }

        private void SetText(Label label, string value)
        {
            label.Text = value;
        }

        private void SetPoster(Movie movie)
        {
            if (movie.Poster?.Image == null)
            {
                labelMissingPoster.Visible = true;
                return;
            }

            pictureBoxPoster.Image = ByteToImage(movie.Poster.Image);
            pictureBoxPoster.Visible = true;
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private static Bitmap ByteToImage(byte[] bytes)
        {
            var memoryStream = new MemoryStream();
            memoryStream.Write(bytes, 0, Convert.ToInt32(bytes.Length));
            var bitmap = new Bitmap(memoryStream, false);
            memoryStream.Dispose();

            return bitmap;
        }
    }
}
