using Cataloguer.UI.ViewModels;
using System;
using System.Windows.Forms;

namespace Cataloguer.UI
{
    public partial class Cataloguer : Form
    {
        private readonly Func<Type, Form> _crudFormFactory;

        public Cataloguer(Func<Type, Form> crudFormFactory)
        {
            InitializeComponent();

            _crudFormFactory = crudFormFactory;

            LinkModelsTypes();
        }

        private void LinkModelsTypes()
        {
            companiesMenuItem.Tag = typeof(CompanyViewModel);
            qualitiesMenuItem.Tag = typeof(QualityViewModel);
            formatsMenuItem.Tag = typeof(FormatViewModel);
            genresMenuItem.Tag = typeof(GenreViewModel);
        }

        private void MenuGroupMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Form crudForm = _crudFormFactory((Type)e.ClickedItem.Tag);
            crudForm.FormClosed += (object senderInner, FormClosedEventArgs args) => Show();
            crudForm.Text = e.ClickedItem.Text;

            Hide();
            crudForm.Show();
        }
    }
}
