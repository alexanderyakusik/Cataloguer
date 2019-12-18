using Cataloguer.UI.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Cataloguer.UI.FormControls.Dropdown
{
    public class FormDropdown : LabelledFormControl<int?>
    {
        private readonly DropdownValue[] _values;
        private ComboBox _comboBox;

        public override int? Value
        {
            get => (_comboBox.SelectedItem as DropdownValue)?.Key;

            set
            {
                DropdownValue dropdownValue = _values.First(val => val.Key == value);
                _comboBox.SelectedIndex = _comboBox.FindStringExact(dropdownValue.Value);
            }
        }

        public FormDropdown(string labelText, IEnumerable<DropdownValue> values) : base(labelText)
        {
            _values = values.ToArray();
        }

        protected override Control CreateControl()
        {
            var container = base.CreateControl();

            _comboBox = new ComboBox
            {
                Font = Defaults.Font,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = OffsetFromLast(container, dx: 3, dy: 3)
            };
            _comboBox.Items.AddRange(_values);

            container.SizeChanged += (sender, e) => _comboBox.Width = GetFullWidth(_comboBox, container);

            return container
                .With(_comboBox);
        }
    }
}
