using System.Windows.Forms;

namespace Cataloguer.UI.Extensions
{
    public static class ControlExtensions
    {
        public static Control With(this Control control, Control toAdd)
        {
            control.Controls.Add(toAdd);

            return control;
        }
    }
}
