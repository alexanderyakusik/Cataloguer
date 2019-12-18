using System.Drawing;
using System.Windows.Forms;

namespace Cataloguer.UI.FormControls
{
    public static class Defaults
    {
        public static Control Container => new Panel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink,
        };

        public static Control Margin(int height) => new Panel
        {
            Dock = DockStyle.Top,
            Height = height,
        };

        public static Font Font { get; } = new Font("Microsoft Sans Serif", 9.25f);
    }
}
