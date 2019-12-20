namespace Cataloguer.UI.FormControls.Dropdown
{
    public class FormSimpleDropdown : BaseFormDropdown<string>
    {
        public override string Value
        {
            get => ComboBox.SelectedItem as string;
            set => ComboBox.SelectedIndex = ComboBox.FindStringExact(value);
        }

        public FormSimpleDropdown(string labelText, string[] values) : base(labelText, values)
        {
        }
    }
}
