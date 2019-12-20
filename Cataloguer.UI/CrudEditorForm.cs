using Cataloguer.DomainLogic.Interfaces.Exceptions;
using Cataloguer.UI.Enums;
using Cataloguer.UI.Events;
using Cataloguer.UI.FormControls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cataloguer.UI
{
    public partial class CrudEditorForm<T> : Form
    {
        private readonly FormControl<T> _formControl;

        public event EventHandler<ItemSavedEventArgs<T>> ItemSaved;
        public event EventHandler SearchResultsCleared;

        public CrudEditorForm(T @object, ViewType viewType, FormControl<T> formControl)
        {
            InitializeComponent();

            _formControl = formControl;

            InitializeView(viewType);
            InitializeForm(@object, formControl);
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            RaiseItemSaved(_formControl.Value);
        }

        private void RaiseItemSaved(T @object)
        {
            var args = new ItemSavedEventArgs<T>(@object);
            ItemSaved?.Invoke(this, args);
        }

        private void InitializeView(ViewType viewType)
        {
            string buttonSaveText, formName;
            buttonSaveText = formName = string.Empty;

            switch (viewType)
            {
                case ViewType.Create:
                    buttonSaveText = "Добавить";
                    formName = "Добавление объекта";
                    break;
                case ViewType.Update:
                    buttonSaveText = "Обновить";
                    formName = "Обновление объекта";
                    break;
                case ViewType.Search:
                    buttonSaveText = formName = "Поиск";
                    buttonClearSearch.Visible = true;
                    break;
            }

            buttonSave.Text = buttonSaveText;
            Text = formName;
        }

        private void InitializeForm(T @object, FormControl<T> formControl)
        {
            try
            {
                panelForm.Controls.Add(formControl);
                formControl.Value = @object;
            }
            catch (ValidationException e)
            {
                MessageBox.Show(e.Message, "Ошибка инициализации формы");
            }
        }

        private void PanelForm_SizeChanged(object sender, EventArgs e)
        {
            buttonSave.Location = GetNewPoint(buttonSave, panelForm);
            buttonBack.Location = GetNewPoint(buttonBack, panelForm);
            buttonClearSearch.Location = GetNewPoint(buttonClearSearch, panelForm);
            Height = buttonSave.Location.Y + buttonSave.Height + 60;
        }

        private Point GetNewPoint(Control control, Control from)
        {
            return new Point
            {
                X = control.Location.X,
                Y = from.Location.Y + from.Height + 20,
            };
        }

        private void ButtonClearSearch_Click(object sender, EventArgs e)
        {
            SearchResultsCleared?.Invoke(this, new EventArgs());
        }
    }
}