using System.Drawing;
using System.Windows.Forms;

namespace Cataloguer.UI.FormControls
{
    public static class Defaults
    {
        public static Control Container => new Panel { Dock = DockStyle.Top };

        public static Font Font { get; } = new Font("Microsoft Sans Serif", 9.25f);
    }
}
