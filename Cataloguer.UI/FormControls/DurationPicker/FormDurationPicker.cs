using System;
using Cataloguer.UI.Extensions;
using System.Windows.Forms;

namespace Cataloguer.UI.FormControls.TimePicker
{
    public class FormDurationPicker : LabelledFormControl<TimeSpan>
    {
        private DateTimePicker _durationPicker;

        public override TimeSpan Value 
        {
            get => _durationPicker.Value - new DateTime(_durationPicker.Value.Year, _durationPicker.Value.Month, _durationPicker.Value.Day);

            set
            {
                var now = DateTime.Now;
                _durationPicker.Value = new DateTime(now.Year, now.Month, now.Day) + value;
            }
        }

        public FormDurationPicker(string labelText) : base(labelText)
        {
        }

        protected override Control CreateControl()
        {
            var container = base.CreateControl();

            var now = DateTime.Now;
            _durationPicker = new DateTimePicker
            {
                Location = OffsetFromLast(container, dx: 3, dy: 3),
                Font = Defaults.Font,
                ShowUpDown = true,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "HH 'ч' mm' мин'",
                Value = new DateTime(now.Year, now.Month, now.Day),
            };

            container.SizeChanged += (sender, e) => _durationPicker.Width = GetFullWidth(_durationPicker, container);

            return container
                .With(_durationPicker);
        }
    }
}