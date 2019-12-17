using System.Windows.Forms;
using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.UI.Extensions;
using Cataloguer.UI.FormControls.Dropdown;
using Cataloguer.UI.ViewModels;

namespace Cataloguer.UI.FormControls.Models
{
    public class MovieFormControl : FormControl<MovieViewModel>
    {
        private readonly Movie _value = new Movie();
        private FormTextBox _nameControl;
        private FormDropdown _companyControl;

        public override MovieViewModel Value { get; set; }

        protected override Control CreateControl()
        {
            return Defaults.Container
                .With(_nameControl = new FormTextBox("Название"))
                .With(_companyControl = new FormDropdown("Компания"));
        }
    }
}
