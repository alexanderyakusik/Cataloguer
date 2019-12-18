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
            get => _durationPicker.Value - new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            set => _durationPicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) + value;
        }

        public FormDurationPicker(string labelText) : base(labelText)
        {
        }

        protected override Control CreateControl()
        {
            var container = base.CreateControl();

            _durationPicker = new DateTimePicker
            {
                Location = OffsetFromLast(container, dx: 3, dy: 3),
                Font = Defaults.Font,
                ShowUpDown = true,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "HH 'ч' mm' мин'",
                Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
            };

            container.SizeChanged += (sender, e) => _durationPicker.Width = GetFullWidth(_durationPicker, container);

            return container
                .With(_durationPicker);
        }
    }
}