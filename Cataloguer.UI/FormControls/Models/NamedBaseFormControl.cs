using Cataloguer.UI.Extensions;
using Cataloguer.UI.ViewModels.BaseClasses;
using System.Windows.Forms;

namespace Cataloguer.UI.FormControls.Models
{
    public class NamedBaseFormControl<T> : FormControl<T> where T : NamedBaseViewModel, new()
    {
        private readonly T _model = new T();
        private FormTextBox _nameControl;

        public override T Value
        {
            get
            {
                _model.Name = _nameControl.Value;
                return _model;
            }

            set
            {
                if (value == null)
                {
                    return;
                }

                _model.Id = value.Id;
                _model.Name = value.Name;

                _nameControl.Value = value.Name;
            }
        }

        protected override Control CreateControl()
        {
            return Defaults.Container
                .With(_nameControl = new FormTextBox("Название"));
        }
    }
}
