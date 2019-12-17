using Cataloguer.UI.Extensions;
using System.Drawing;
using System.Windows.Forms;

namespace Cataloguer.UI.FormControls
{
    public class FormTextBox : FormControl<string>
    {
        private readonly string _labelText;
        private TextBox _textBox;

        public override string Value
        {
            get => _textBox.Text;
            set => _textBox.Text = value;
        }

        public FormTextBox(string labelText)
        {
            _labelText = labelText;
        }

        protected override Control CreateControl()
        {
            var font = new Font("Microsoft Sans Serif", 9.25f);

            var container = new Container();
            var label = new Label { Text = $"{_labelText}:", Font = font };
            _textBox = new TextBox
            {
                Location = Offset(label, dx: 3, dy: 3),
                Font = font,
            };

            container.Control.SizeChanged +=
                (sender, e) => _textBox.Width = container.Control.Size.Width - 2 * _textBox.Location.X - 1;

            return container
                .With(label)
                .With(_textBox);
        }
    }
}
