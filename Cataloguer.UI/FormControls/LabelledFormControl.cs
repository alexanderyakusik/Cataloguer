using Cataloguer.UI.Extensions;
using System.Drawing;
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
            Control container = Defaults.Container;

            var label = new Label
            {
                Text = _labelText,
                Font = Defaults.Font,
                AutoSize = false,
                TextAlign = ContentAlignment.TopLeft,
            };

            container.SizeChanged += (sender, e) => label.Width = GetFullWidth(label, container);

            return container
                .With(label);
        }
    }
}
