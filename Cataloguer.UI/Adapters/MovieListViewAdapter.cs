using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.UI.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Cataloguer.UI.Adapters
{
    public class MovieListViewAdapter : BaseListViewAdapter<Movie>
    {
        public override string ViewName => "Фильмы";

        protected override Dictionary<string, string> Mappings { get; } = new Dictionary<string, string>()
        {
            { nameof(Movie.Name), "Название" },
            { nameof(Movie.Genre), "Жанр" },
            { nameof(Movie.Runtime), "Продолжительность" },
            { nameof(Movie.Quality), "Качество" },
        };

        public override IEnumerable<ListViewItem> GetItems(IEnumerable<Movie> models)
        {
            return models
                .Select(item =>
                {
                    var li = new ListViewItem
                    {
                        Text = item.Name,
                        Tag = item.Id,
                    };

                    li.SubItems.AddRange(new[]
                    {
                        item.Genre.Name,
                        item.Runtime.ToShortForm(),
                        item.Quality.Name
                    });

                    return li;
                });
        }
    }
}
