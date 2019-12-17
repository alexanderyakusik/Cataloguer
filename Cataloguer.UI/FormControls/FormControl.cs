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

        protected Point Offset(Control from, int dx, int dy)
        {
            Point point = from.Location;
            point.Offset(0, from.Size.Height);
            point.Offset(dx, dy);

            return point;
        }
    }
}
