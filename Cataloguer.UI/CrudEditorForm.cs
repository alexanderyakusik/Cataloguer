using Cataloguer.DomainLogic.Interfaces.Models.BaseClasses;
using Cataloguer.UI.Events;
using Cataloguer.UI.FormControls;
using System;
using System.Windows.Forms;

namespace Cataloguer.UI
{
    public partial class CrudEditorForm<T> : Form where T : BaseModel
    {
        private readonly FormControl<T> _formControl;

        public event EventHandler<ItemSavedEventArgs<T>> ItemSaved;

        public CrudEditorForm(T @object, bool isCreateMode, FormControl<T> formControl)
        {
            InitializeComponent();

            _formControl = formControl;

            InitializeView(isCreateMode);
            InitializeForm(@object, formControl);
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (RaiseItemSaved(_formControl.Value))
            {
                Close();
            }
        }

        private bool RaiseItemSaved(T @object)
        {
            var args = new ItemSavedEventArgs<T>(@object);
            ItemSaved?.Invoke(this, args);

            return args.IsHandled;
        }

        private void InitializeView(bool isCreateMode)
        {
            buttonSave.Text = isCreateMode ? "Добавить" : "Обновить";
            Text = isCreateMode ? "Добавление объекта" : "Обновление объекта";
        }

        private void InitializeForm(T @object, FormControl<T> formControl)
        {
            panelForm.Controls.Add(formControl);
            formControl.Value = @object;
        }
    }
}