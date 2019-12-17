using Cataloguer.DomainLogic.Interfaces.Exceptions;
using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.Infrastructure.Mapping;
using Cataloguer.UI.Adapters;
using Cataloguer.UI.Events;
using Cataloguer.UI.ViewModels;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Cataloguer.UI
{
    public partial class MovieForm : Form
    {
        private readonly Func<Type, Form> _crudFormFactory;
        private readonly Func<MovieViewModel, bool, CrudEditorForm<MovieViewModel>> _crudEditorFormFactory;
        private readonly Mapper _mapper;
        private readonly IListViewAdapter<MovieViewModel> _adapter;
        private readonly ICrudService<Movie> _service;

        public MovieForm(
            Func<Type, Form> crudFormFactory,
            ICrudService<Movie> service,
            IListViewAdapter<MovieViewModel> adapter,
            Mapper mapper,
            Func<MovieViewModel, bool, CrudEditorForm<MovieViewModel>> crudEditorFormFactory
        )
        {
            InitializeComponent();

            _crudEditorFormFactory = crudEditorFormFactory;
            _crudFormFactory = crudFormFactory;
            _service = service;
            _adapter = adapter;
            _mapper = mapper;

            LinkModelsTypes();
            InitializeView();
            UpdateViewData();
        }

        private void LinkModelsTypes()
        {
            companiesMenuItem.Tag = typeof(CompanyViewModel);
            qualitiesMenuItem.Tag = typeof(QualityViewModel);
            formatsMenuItem.Tag = typeof(FormatViewModel);
            genresMenuItem.Tag = typeof(GenreViewModel);
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
                    .GetItems(_service.GetAll().Select(_mapper.Map<MovieViewModel>))
                    .ToArray()
            );
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
            MovieViewModel viewObject = _mapper.Map<MovieViewModel>(_service.Get(id));

            InitializeEditorForm(viewObject, false, OnItemUpdated);
        }

        private void InitializeEditorForm(
            MovieViewModel @object,
            bool isCreateMode,
            EventHandler<ItemSavedEventArgs<MovieViewModel>> handler
        )
        {
            CrudEditorForm<MovieViewModel> editorForm = _crudEditorFormFactory(@object, isCreateMode);

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

        private void OnItemCreated(object sender, ItemSavedEventArgs<MovieViewModel> e)
        {
            e.IsHandled = OnItemSaved(() => _service.Create(_mapper.Map<Movie>(e.Item)), true);
        }

        private void OnItemUpdated(object sender, ItemSavedEventArgs<MovieViewModel> e)
        {
            e.IsHandled = OnItemSaved(() => _service.Update(_mapper.Map<Movie>(e.Item)), false);
        }
    }
}
