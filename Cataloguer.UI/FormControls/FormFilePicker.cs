using Cataloguer.UI.Extensions;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Cataloguer.UI.FormControls
{
    public class FormFilePicker : LabelledFormControl<byte[]>
    {
        private readonly OpenFileDialog _dialog = new OpenFileDialog()
        {
            Filter = "Графические файлы (*.bmp; *.jpg; *.jpeg; *.png)|*.bmp;*.jpg;*.jpeg;*.png",
        };

        private Label _fileNameLabel;
        private byte[] _fileContents;

        public override byte[] Value
        {
            get => _fileContents;

            set
            {
                _fileContents = value;
                _fileNameLabel.Visible = false;
            }
        }

        public FormFilePicker(string labelText) : base(labelText)
        {
        }

        protected override Control CreateControl()
        {
            Control container = base.CreateControl();

            Button button = CreateButton(container);
            container.Controls.Add(button);

            _fileNameLabel = new Label
            {
                Font = Defaults.Font,
                Location = OffsetFromLast(container, dx: 8, dy: 3, horizontal: true),
                Text = "Файл не выбран",
                TextAlign = ContentAlignment.MiddleLeft,
                Visible = false,
                AutoSize = false,
                AutoEllipsis = true,
            };

            container.SizeChanged +=
                (sender, e) =>
                _fileNameLabel.Width = container.Width - _fileNameLabel.Location.X - 1;

            return container
                .With(_fileNameLabel);
        }

        private Button CreateButton(Control container)
        {
            var button = new Button
            {
                Font = Defaults.Font,
                Location = OffsetFromLast(container, dx: 3, dy: 2),
                Text = "Выбрать файл...",
                AutoSize = true,
            };

            button.Click += OnButtonClick;

            return button;
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            if (_dialog.ShowDialog() == DialogResult.OK)
            {
                _fileNameLabel.Text = Path.GetFileName(_dialog.FileName);
                _fileNameLabel.Visible = true;

                _fileContents = File.ReadAllBytes(_dialog.FileName);
            }
        }
    }
}
