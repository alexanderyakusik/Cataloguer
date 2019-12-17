using Cataloguer.UI.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Cataloguer.UI.Adapters
{
    public class MovieListViewAdapter : BaseListViewAdapter<MovieViewModel>
    {
        public override string ViewName => "Фильмы";

        protected override Dictionary<string, string> Mappings { get; } = new Dictionary<string, string>()
        {
            { nameof(MovieViewModel.Name), "Название" },
            { nameof(MovieViewModel.Genre), "Жанр" },
            { nameof(MovieViewModel.Runtime), "Длительность" },
            { nameof(MovieViewModel.Quality), "Качество" },
        };

        public override IEnumerable<ListViewItem> GetItems(IEnumerable<MovieViewModel> models)
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
                        $"{item.Runtime.Hours}ч {item.Runtime.Minutes}мин",
                        item.Quality.Name
                    });

                    return li;
                });
        }
    }
}
