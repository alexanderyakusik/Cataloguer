using Cataloguer.DomainLogic.Interfaces.Exceptions;
using Cataloguer.DomainLogic.Interfaces.Models.BaseClasses;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.Infrastructure.Mapping;
using Cataloguer.UI.Adapters;
using Cataloguer.UI.Events;
using Cataloguer.UI.ViewModels.BaseClasses;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Cataloguer.UI
{
    public partial class CrudForm<TView, TModel> : Form
        where TModel : BaseModel
        where TView : BaseViewModel
    {
        private readonly Mapper _mapper;
        private readonly IListViewAdapter<TView> _adapter;
        private readonly ICrudService<TModel> _service;
        private readonly Func<TView, bool, CrudEditorForm<TView>> _editorFormFactory;

        public CrudForm(
            ICrudService<TModel> service,
            IListViewAdapter<TView> adapter,
            Mapper mapper,
            Func<TView, bool, CrudEditorForm<TView>> editorFormFactory
        )
        {
            InitializeComponent();

            _service = service;
            _adapter = adapter;
            _mapper = mapper;
            _editorFormFactory = editorFormFactory;

            InitializeView();
            UpdateViewData();
        }

        private void InitializeView()
        {
            listViewLabel.Text = _adapter.ViewName;
            listView.Columns.AddRange(_adapter.GetColumns().ToArray());

            listView.Columns[listView.Columns.Count - 1].Width = -2;
        }

        private void UpdateViewData()
        {
            listView.Items.Clear();

            listView.Items.AddRange(
                _adapter
                    .GetItems(_service.GetAll().Select(_mapper.Map<TView>))
                    .ToArray()
            );
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            InitializeEditorForm(default, true, OnItemCreated);
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            int id = GetSelectedItemId();
            TView viewObject = _mapper.Map<TView>(_service.Get(id));

            InitializeEditorForm(viewObject, false, OnItemUpdated);
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

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isItemSelected = listView.SelectedItems.Count > 0;
            buttonUpdate.Enabled = buttonDelete.Enabled = isItemSelected;
        }

        private int GetSelectedItemId()
        {
            return _adapter.GetItemId(listView.SelectedItems[0]);
        }

        private void InitializeEditorForm(
            TView @object,
            bool isCreateMode,
            EventHandler<ItemSavedEventArgs<TView>> handler
        )
        {
            CrudEditorForm<TView> editorForm = _editorFormFactory(@object, isCreateMode);

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

        private void OnItemCreated(object sender, ItemSavedEventArgs<TView> e)
        {
            e.IsHandled = OnItemSaved(() => _service.Create(_mapper.Map<TModel>(e.Item)), true);
        }

        private void OnItemUpdated(object sender, ItemSavedEventArgs<TView> e)
        {
            e.IsHandled = OnItemSaved(() => _service.Update(_mapper.Map<TModel>(e.Item)), false);
        }
    }
}
