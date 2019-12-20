using System;
using Cataloguer.UI.Extensions;
using System.Windows.Forms;

namespace Cataloguer.UI.FormControls.DatePicker
{
    public class FormDatePicker : LabelledFormControl<DateTime>
    {
        private DateTimePicker _datePicker;

        public override DateTime Value 
        {
            get => _datePicker.Value.Date;
            set => _datePicker.Value = value;
        }

        public FormDatePicker(string labelText) : base(labelText)
        {
        }

        protected override Control CreateControl()
        {
            var container = base.CreateControl();

            _datePicker = new DateTimePicker
            {
                Location = OffsetFromLast(container, dx: 3, dy: 3),
                Font = Defaults.Font,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd MMMM yyyy",
            };

            container.SizeChanged += (sender, e) => _datePicker.Width = GetFullWidth(_datePicker, container);

            return container
                .With(_datePicker);
        }
    }
}
