using Cataloguer.DomainLogic.Interfaces.Models;
using Cataloguer.DomainLogic.Interfaces.Models.BaseClasses;
using Cataloguer.DomainLogic.Interfaces.Models.Search;
using Cataloguer.UI.Extensions;
using Cataloguer.UI.FormControls.DatePicker;
using Cataloguer.UI.FormControls.Dropdown;
using Cataloguer.UI.FormControls.Search;
using Cataloguer.UI.FormControls.TimePicker;
using Cataloguer.UI.Providers.Dropdown;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Cataloguer.UI.FormControls.Models
{
    public class MovieSearchFormControl : FormControl<MovieSearchModel>
    {
        private readonly MovieSearchModel _value = new MovieSearchModel();

        private readonly string[] _additionalDropdownValues = new[] { "" };
        private readonly string[] _companyValues;
        private readonly string[] _genreValues;
        private readonly string[] _formatValues;
        private readonly string[] _qualityValues;

        private FormTextBox _nameControl;
        private FormSimpleDropdown _companyControl;
        private FormSimpleDropdown _genreControl;
        private FormSimpleDropdown _qualityControl;
        private FormSimpleDropdown _formatControl;
        private SearchFormControl<DateTime> _releaseDateControl;
        private SearchFormControl<TimeSpan> _durationControl;

        public override MovieSearchModel Value
        {
            get
            {
                _value.Name = _nameControl.Value;
                _value.CompanyName = _companyControl.Value;
                _value.GenreName = _genreControl.Value;
                _value.FormatName = _formatControl.Value;
                _value.QualityName = _qualityControl.Value;
                _value.RuntimeComparison = _durationControl.Value;
                _value.ReleaseDateComparison = _releaseDateControl.Value;

                return _value;
            }

            set
            {
                if (value == null)
                {
                    return;
                }

                throw new NotImplementedException();
            }
        }

        public MovieSearchFormControl(
            DropdownValuesProvider<Company> companyValuesProvider,
            DropdownValuesProvider<Genre> genreValuesProvider,
            DropdownValuesProvider<Quality> qualityValuesProvider,
            DropdownValuesProvider<Format> formatValuesProvider
        )
        {
            _companyValues = GetDropdownValues(companyValuesProvider);
            _genreValues = GetDropdownValues(genreValuesProvider);
            _qualityValues = GetDropdownValues(qualityValuesProvider);
            _formatValues = GetDropdownValues(formatValuesProvider);
        }

        protected override Control CreateControl()
        {
            return Defaults.Container
                .With(_formatControl = new FormSimpleDropdown("Формат", _formatValues))
                .With(Defaults.Margin(10))
                .With(_qualityControl = new FormSimpleDropdown("Качество", _qualityValues))
                .With(Defaults.Margin(10))
                .With(_companyControl = new FormSimpleDropdown("Компания", _companyValues))
                .With(Defaults.Margin(10))
                .With(_durationControl = new SearchFormControl<TimeSpan>(new FormDurationPicker("Продолжительность")))
                .With(Defaults.Margin(10))
                .With(_genreControl = new FormSimpleDropdown("Жанр", _genreValues))
                .With(Defaults.Margin(10))
                .With(_releaseDateControl = new SearchFormControl<DateTime>(new FormDatePicker("Дата выхода")))
                .With(Defaults.Margin(10))
                .With(_nameControl = new FormTextBox("Название"));
        }

        private string[] GetDropdownValues<T>(DropdownValuesProvider<T> provider) where T : BaseModel
        {
            return _additionalDropdownValues
                .Concat(provider.GetValues().Select(item => item.Value))
                .ToArray();
        }
    }
}
