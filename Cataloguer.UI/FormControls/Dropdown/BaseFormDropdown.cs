using Cataloguer.UI.Extensions;
using System.Linq;
using System.Windows.Forms;

namespace Cataloguer.UI.FormControls.Dropdown
{
    public abstract class BaseFormDropdown<T> : LabelledFormControl<T>
    {
        private readonly object[] _values;

        protected ComboBox ComboBox { get; private set; }

        protected BaseFormDropdown(string labelText, object[] values) : base(labelText)
        {
            _values = values.ToArray();
        }

        protected override Control CreateControl()
        {
            var container = base.CreateControl();

            ComboBox = new ComboBox
            {
                Font = Defaults.Font,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = OffsetFromLast(container, dx: 3, dy: 3)
            };
            ComboBox.Items.AddRange(_values);

            container.SizeChanged += (sender, e) => ComboBox.Width = GetFullWidth(ComboBox, container);

            return container
                .With(ComboBox);
        }
    }
}
