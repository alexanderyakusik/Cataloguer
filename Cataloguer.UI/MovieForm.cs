using Cataloguer.DomainLogic.Interfaces.Exceptions;
using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.DomainLogic.Interfaces.Models.Search;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.UI.Adapters;
using Cataloguer.UI.Enums;
using Cataloguer.UI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Cataloguer.UI
{
    public partial class MovieForm : Form
    {
        private readonly Func<Type, Form> _crudFormFactory;
        private readonly Func<Movie, ViewType, CrudEditorForm<Movie>> _editorFormFactory;
        private readonly Func<CrudEditorForm<MovieSearchModel>> _searchFormFactory;
        private readonly Func<int, MovieDetailsForm> _movieDetailsFormFactory;
        private readonly IListViewAdapter<Movie> _adapter;
        private readonly IMovieService _service;

        private CrudEditorForm<MovieSearchModel> _searchForm;

        public MovieForm(
            Func<Type, Form> crudFormFactory,
            IMovieService service,
            IListViewAdapter<Movie> adapter,
            Func<Movie, ViewType, CrudEditorForm<Movie>> editorFormFactory,
            Func<CrudEditorForm<MovieSearchModel>> searchFormFactory,
            Func<int, MovieDetailsForm> movieDetailsFormFactory
        )
        {
            InitializeComponent();

            _editorFormFactory = editorFormFactory;
            _searchFormFactory = searchFormFactory;
            _movieDetailsFormFactory = movieDetailsFormFactory;
            _crudFormFactory = crudFormFactory;
            _service = service;
            _adapter = adapter;

            LinkModelsTypes();
            InitializeView();
            UpdateViewData(_service.GetAll());
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

        private void UpdateViewData(IEnumerable<Movie> items)
        {
            listView.Items.Clear();

            listView.Items.AddRange(
                _adapter
                    .GetItems(items)
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

            _searchForm?.Close();
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
            UpdateViewData(_service.GetAll());
        }

        private int GetSelectedItemId()
        {
            return _adapter.GetItemId(listView.SelectedItems[0]);
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            InitializeEditorForm(default, ViewType.Create, OnItemCreated);
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            int id = GetSelectedItemId();
            Movie viewObject = _service.Get(id);

            InitializeEditorForm(viewObject, ViewType.Update, OnItemUpdated);
        }

        private void InitializeEditorForm(
            Movie @object,
            ViewType viewType,
            EventHandler<ItemSavedEventArgs<Movie>> handler
        )
        {
            CrudEditorForm<Movie> editorForm = _editorFormFactory(@object, viewType);

            editorForm.FormClosed += (sender, e) => Show();
            editorForm.ItemSaved += handler;

            _searchForm?.Close();
            Hide();
            editorForm.Show();
        }

        private void OnItemSaved(Form form, Action action, bool isCreateAction)
        {
            try
            {
                action();
                form.Close();
            }
            catch (ValidationException e)
            {
                MessageBox.Show(e.Message, $"Ошибка {(isCreateAction ? "добавления" : "обновления")} объекта");
            }

            UpdateViewData(_service.GetAll());
        }

        private void OnItemCreated(object sender, ItemSavedEventArgs<Movie> e)
        {
            OnItemSaved((Form)sender, () => _service.Create(e.Item), true);
        }

        private void OnItemUpdated(object sender, ItemSavedEventArgs<Movie> e)
        {
            OnItemSaved((Form)sender, () => _service.Update(e.Item), false);
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

            _searchForm?.Close();
            Hide();
            detailsForm.Show();
        }

        private void ButtonSearchPanel_Click(object sender, EventArgs e)
        {
            buttonSearchPanel.Enabled = false;

            _searchForm = _searchFormFactory();
            _searchForm.FormClosed += (_sender, _e) => buttonSearchPanel.Enabled = true;
            _searchForm.ItemSaved += (_sender, _e) => Search(_e.Item);
            _searchForm.SearchResultsCleared += (_sender, _e) => UpdateViewData(_service.GetAll());

            _searchForm.Show();
        }

        private void Search(MovieSearchModel searchModel)
        {
            UpdateViewData(_service.Search(searchModel));
        }
    }
}
