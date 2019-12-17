using Cataloguer.DomainLogic.Interfaces.Models.BaseClasses;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Cataloguer.UI.Adapters
{
    public abstract class BaseListViewAdapter<T> : IListViewAdapter<T> where T : BaseModel
    {
        protected abstract Dictionary<string, string> Mappings { get; }

        public abstract string ViewName { get; }

        public abstract IEnumerable<ListViewItem> GetItems(IEnumerable<T> models);

        public IEnumerable<ColumnHeader> GetColumns()
        {
            return Mappings
                .Values
                .Select(value => new ColumnHeader
                {
                    Text = value,
                    Width = -2,
                });
        }

        public int GetItemId(ListViewItem item)
        {
            return (int)item.Tag;
        }
    }
}
