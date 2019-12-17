using Cataloguer.DomainLogic.Interfaces.Models.BaseClasses;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Cataloguer.UI.Adapters
{
    public abstract class NamedBaseListViewAdapter : BaseListViewAdapter<NamedBaseModel>
    {
        protected override Dictionary<string, string> Mappings => new Dictionary<string, string>
        {
            { nameof(NamedBaseModel.Name), "Название" },
        };

        public override IEnumerable<ListViewItem> GetItems(IEnumerable<NamedBaseModel> models)
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
