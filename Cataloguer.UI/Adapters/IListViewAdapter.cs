using Cataloguer.UI.ViewModels.BaseClasses;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cataloguer.UI.Adapters
{
    public interface IListViewAdapter<in T> where T : BaseViewModel
    {
        string ViewName { get; }

        IEnumerable<ColumnHeader> GetColumns();

        IEnumerable<ListViewItem> GetItems(IEnumerable<T> models);
    }
}
