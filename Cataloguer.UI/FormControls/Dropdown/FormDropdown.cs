using Cataloguer.UI.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Cataloguer.UI.FormControls.Dropdown
{
    public class FormDropdown : BaseFormDropdown<int?>
    {
        private readonly IEnumerable<DropdownValue> _values;

        public override int? Value
        {
            get => (ComboBox.SelectedItem as DropdownValue)?.Key;

            set
            {
                DropdownValue dropdownValue = _values.First(val => val.Key == value);
                ComboBox.SelectedIndex = ComboBox.FindStringExact(dropdownValue.Value);
            }
        }

        public FormDropdown(string labelText, IEnumerable<DropdownValue> values) : base(labelText, values.ToArray())
        {
            _values = values;
        }
    }
}
