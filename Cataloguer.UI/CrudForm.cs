using Cataloguer.DomainLogic.Interfaces.Models.BaseClasses;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.Infrastructure.Mapping;
using Cataloguer.UI.Adapters;
using Cataloguer.UI.ViewModels.BaseClasses;
using System.Linq;
using System.Windows.Forms;

namespace Cataloguer.UI
{
    public partial class CrudForm<TView, TModel> : Form
        where TModel : BaseModel
        where TView : BaseViewModel
    {
        public CrudForm(
            ICrudService<TModel> service,
            IListViewAdapter<TView> adapter,
            Mapper mapper
        )
        {
            InitializeComponent();

            listViewLabel.Text = adapter.ViewName;
            listView.Columns.AddRange(adapter.GetColumns().ToArray());

            listView.Columns[listView.Columns.Count - 1].Width = -2;

            listView.Items.AddRange(
                adapter
                    .GetItems(service.GetAll().Select(mapper.Map<TView>))
                    .ToArray()
            );
        }
    }
}
