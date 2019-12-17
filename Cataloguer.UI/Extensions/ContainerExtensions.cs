using Cataloguer.UI.FormControls;
using System.Windows.Forms;

namespace Cataloguer.UI.Extensions
{
    public static class ContainerExtensions
    {
        public static Container With(this Container container, Control toAdd)
        {
            container.Control.Controls.Add(toAdd);

            return container;
        }
    }
}
