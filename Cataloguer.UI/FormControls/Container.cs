using System.Windows.Forms;

namespace Cataloguer.UI.FormControls
{
    public class Container
    {
        public Control Control { get; }

        public Container()
        {
            Control = new Panel
            {
                Dock = DockStyle.Top,
            };
        }

        public static implicit operator Control(Container container) => container.Control;
    }
}
