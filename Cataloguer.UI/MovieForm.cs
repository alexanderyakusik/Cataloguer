using Cataloguer.DomainLogic.Interfaces.Exceptions;
using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.UI.Adapters;
using Cataloguer.UI.Events;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Cataloguer.UI
{
    public partial class MovieForm : Form
    {
        private readonly Func<Type, Form> _crudFormFactory;
        private readonly Func<Movie, bool, CrudEditorForm<Movie>> _crudEditorFormFactory;
        private readonly Func<int, MovieDetailsForm> _movieDetailsFormFactory;
        private readonly IListViewAdapter<Movie> _adapter;
        private readonly ICrudService<Movie> _service;

        public MovieForm(
            Func<Type, Form> crudFormFactory,
            ICrudService<Movie> service,
            IListViewAdapter<Movie> adapter,
            Func<Movie, bool, CrudEditorForm<Movie>> crudEditorFormFactory,
            Func<int, MovieDetailsForm> movieDetailsFormFactory
        )
        {
            InitializeComponent();

            _crudEditorFormFactory = crudEditorFormFactory;
            _movieDetailsFormFactory = movieDetailsFormFactory;
            _crudFormFactory = crudFormFactory;
            _service = service;
            _adapter = adapter;

            LinkModelsTypes();
            InitializeView();
            UpdateViewData();
        }

        private void LinkModelsTypes()
        {
            companiesMenuItem.Tag = typeof(Company);
            qualitiesMenuItem.Tag = typeof(Quality);
            formatsMenuItem.Tag = typeof(Format);
            genresMenuItem.Tag = typeof(Genre);
        }

        private void InitializeView()
        {
            listViewLabel.Text = _adapter.ViewName;
            listView.Columns.AddRange(_adapter.GetColumns().ToArray());
        }

        private void UpdateViewData()
        {
            listView.Items.Clear();

            listView.Items.AddRange(
                _adapter
                    .GetItems(_service.GetAll())
                    .ToArray()
            );

            UpdateButtons();
        }

        private void UpdateButtons()
        {
            bool isItemSelected = listView.SelectedItems.Count > 0;
            buttonDetails.Enabled = buttonUpdate.Enabled = buttonDelete.Enabled = isItemSelected;
        }

        private void MenuGroupMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Form crudForm = _crudFormFactory((Type)e.ClickedItem.Tag);
            crudForm.FormClosed += (object senderInner, FormClosedEventArgs args) => Show();
            crudForm.Text = e.ClickedItem.Text;

            Hide();
            crudForm.Show();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                "Вы действительно хотите удалить объект?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo
            );

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            int id = GetSelectedItemId();
            _service.Delete(id);
            UpdateViewData();
        }

        private int GetSelectedItemId()
        {
            return _adapter.GetItemId(listView.SelectedItems[0]);
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            InitializeEditorForm(default, true, OnItemCreated);
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            int id = GetSelectedItemId();
            Movie viewObject = _service.Get(id);

            InitializeEditorForm(viewObject, false, OnItemUpdated);
        }

        private void InitializeEditorForm(
            Movie @object,
            bool isCreateMode,
            EventHandler<ItemSavedEventArgs<Movie>> handler
        )
        {
            CrudEditorForm<Movie> editorForm = _crudEditorFormFactory(@object, isCreateMode);

            editorForm.FormClosed += (sender, e) => Show();
            editorForm.ItemSaved += handler;

            Hide();
            editorForm.Show();
        }

        private bool OnItemSaved(Action action, bool isCreateAction)
        {
            try
            {
                action();
            }
            catch (ValidationException e)
            {
                MessageBox.Show(e.Message, $"Ошибка {(isCreateAction ? "добавления" : "обновления")} объекта");
                return false;
            }

            UpdateViewData();

            return true;
        }

        private void OnItemCreated(object sender, ItemSavedEventArgs<Movie> e)
        {
            e.IsHandled = OnItemSaved(() => _service.Create(e.Item), true);
        }

        private void OnItemUpdated(object sender, ItemSavedEventArgs<Movie> e)
        {
            e.IsHandled = OnItemSaved(() => _service.Update(e.Item), false);
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void ButtonDetails_Click(object sender, EventArgs e)
        {
            int id = GetSelectedItemId();
            MovieDetailsForm detailsForm = _movieDetailsFormFactory(id);

            detailsForm.FormClosed += (_sender, _e) => Show();

            Hide();
            detailsForm.Show();
        }
    }
}
