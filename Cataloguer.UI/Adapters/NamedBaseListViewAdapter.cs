using Cataloguer.UI.ViewModels.BaseClasses;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Cataloguer.UI.Adapters
{
    public abstract class NamedBaseListViewAdapter : BaseListViewAdapter<NamedBaseViewModel>
    {
        protected override Dictionary<string, string> Mappings { get; } = new Dictionary<string, string>
        {
            { nameof(NamedBaseViewModel.Name), "Название" },
        };

        public override IEnumerable<ListViewItem> GetItems(IEnumerable<NamedBaseViewModel> models)
        {
            return models
                .Select(model => new ListViewItem
                {
                    Text = model.Name,
                    Tag = model.Id,
                });
        }
    }
}
