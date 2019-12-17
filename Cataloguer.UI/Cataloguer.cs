using Cataloguer.DomainLogic.Interfaces.Models;
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
            companiesMenuItem.Tag = typeof(Company);
            qualitiesMenuItem.Tag = typeof(Quality);
            formatsMenuItem.Tag = typeof(Format);
            genresMenuItem.Tag = typeof(Genre);
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
