using Cataloguer.UI.Extensions;
using System.Windows.Forms;

namespace Cataloguer.UI.FormControls
{
    public class FormTextBox : LabelledFormControl<string>
    {
        private TextBox _textBox;

        public override string Value
        {
            get => _textBox.Text;
            set => _textBox.Text = value;
        }

        public FormTextBox(string labelText) : base(labelText)
        {
        }

        protected override Control CreateControl()
        {
            var container = base.CreateControl();

            _textBox = new TextBox
            {
                Location = OffsetFromLast(container, dx: 3, dy: 3),
                Font = Defaults.Font,
            };

            container.SizeChanged += (sender, e) => _textBox.Width = GetFullWidth(container, _textBox);

            return container
                .With(_textBox);
        }
    }
}
