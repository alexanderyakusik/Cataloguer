using Cataloguer.DomainLogic.Interfaces.Models.BaseClasses;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cataloguer.UI.Adapters
{
    public interface IListViewAdapter<in T> where T : BaseModel
    {
        string ViewName { get; }

        IEnumerable<ColumnHeader> GetColumns();

        IEnumerable<ListViewItem> GetItems(IEnumerable<T> models);

        int GetItemId(ListViewItem item);
    }
}
