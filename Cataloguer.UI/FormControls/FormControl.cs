using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cataloguer.UI.FormControls
{
    public abstract class FormControl<T> 
    {
        private readonly Lazy<Control> _control;

        public Control Control => _control.Value;

        public abstract T Value { get; set; }

        public static implicit operator Control(FormControl<T> formControl) => formControl.Control;

        protected FormControl()
        {
            _control = new Lazy<Control>(CreateControl);
        }

        protected abstract Control CreateControl();

        protected Point Offset(Control from, int dx, int dy, bool horizontal = false)
        {
            Point point = from.Location;
            if (horizontal)
            {
                point.Offset(from.Size.Width, 0);
            }
            else
            {
                point.Offset(0, from.Size.Height);
            }
            point.Offset(dx, dy);

            return point;
        }

        protected Point OffsetFromLast(Control container, int dx, int dy, bool horizontal = false)
        {
            Control lastChild = container.Controls[container.Controls.Count - 1];

            return Offset(lastChild, dx, dy, horizontal);
        }

        protected int GetFullWidth(Control control, Control container)
        {
            return container.Size.Width - 2 * control.Location.X - 1;
        }
    }
}
