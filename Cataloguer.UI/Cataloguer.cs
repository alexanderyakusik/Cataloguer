using Cataloguer.Infrastructure.Configuration;
using System.Windows.Forms;

namespace Cataloguer.UI
{
    public partial class Cataloguer : Form
    {
        public Cataloguer(AppConfiguration configuration)
        {
            InitializeComponent();
        }
    }
}
