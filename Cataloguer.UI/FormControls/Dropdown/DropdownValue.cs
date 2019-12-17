namespace Cataloguer.UI.FormControls.Dropdown
{
    public class DropdownValue
    {
        public int Key { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
