using Cataloguer.UI.Extensions;
using System.Windows.Forms;

namespace Cataloguer.UI.FormControls
{
    public abstract class LabelledFormControl<T> : FormControl<T>
    {
        private readonly string _labelText;

        protected LabelledFormControl(string labelText)
        {
            _labelText = labelText;
        }

        protected override Control CreateControl()
        {
            var label = new Label { Text = _labelText, Font = Defaults.Font };

            return Defaults.Container
                .With(label);
        }
    }
}
