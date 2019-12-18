using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.UI.Extensions;
using Cataloguer.UI.FormControls.DatePicker;
using Cataloguer.UI.FormControls.Dropdown;
using Cataloguer.UI.FormControls.TimePicker;
using Cataloguer.UI.Providers.Dropdown;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cataloguer.UI.FormControls.Models
{
    public class MovieFormControl : FormControl<Movie>
    {
        private readonly Movie _value = new Movie
        {
            Company = new Company(),
            Genre = new Genre(),
            Format = new Format(),
            Quality = new Quality(),
            Poster = new Poster { Image = new byte[] { 1, 2, 3 } }
        };

        private readonly IEnumerable<DropdownValue> _companyValues;
        private readonly IEnumerable<DropdownValue> _genreValues;
        private readonly IEnumerable<DropdownValue> _formatValues;
        private readonly IEnumerable<DropdownValue> _qualityValues;

        private FormTextBox _nameControl;
        private FormDropdown _companyControl;
        private FormDropdown _genreControl;
        private FormDropdown _qualityControl;
        private FormDropdown _formatControl;
        private FormDatePicker _dateControl;
        private FormDurationPicker _durationControl; 

        public override Movie Value
        {
            get
            {
                _value.Name = _nameControl.Value;
                _value.Company.Id = _companyControl.Value ?? 0;
                _value.Genre.Id = _genreControl.Value ?? 0;
                _value.Format.Id = _formatControl.Value ?? 0;
                _value.Quality.Id = _qualityControl.Value ?? 0;

                return _value;
            }

            set
            {
                if (value == null)
                {
                    return;
                }

                _value.Id = value.Id;
                _nameControl.Value = _value.Name = value.Name;
                _companyControl.Value = _value.Company.Id = value.Company.Id;
                _genreControl.Value = _value.Genre.Id = value.Genre.Id;
                _formatControl.Value = _value.Format.Id = value.Format.Id;
                _qualityControl.Value = _value.Quality.Id = value.Quality.Id;
                _value.Poster.Id = value.Poster.Id;
            }
        }

        public MovieFormControl(
            DropdownValuesProvider<Company> companyValuesProvider,
            DropdownValuesProvider<Genre> genreValuesProvider,
            DropdownValuesProvider<Quality> qualityValuesProvider,
            DropdownValuesProvider<Format> formatValuesProvider
        )
        {
            _companyValues = companyValuesProvider.GetValues();
            _genreValues = genreValuesProvider.GetValues();
            _qualityValues = qualityValuesProvider.GetValues();
            _formatValues = formatValuesProvider.GetValues();
        }

        protected override Control CreateControl()
        {
            return Defaults.Container
                .With(_formatControl = new FormDropdown("Формат", _formatValues))
                .With(Defaults.Margin(10))
                .With(_qualityControl = new FormDropdown("Качество", _qualityValues))
                .With(Defaults.Margin(10))
                .With(_companyControl = new FormDropdown("Компания", _companyValues))
                .With(Defaults.Margin(10))
                .With(_durationControl = new FormDurationPicker("Длительность"))
                .With(Defaults.Margin(10))
                .With(_genreControl = new FormDropdown("Жанр", _genreValues))
                .With(Defaults.Margin(10))
                .With(_dateControl = new FormDatePicker("Дата выхода"))
                .With(Defaults.Margin(10))
                .With(_nameControl = new FormTextBox("Название"));
        }
    }
}
