using Cataloguer.DomainLogic.Interfaces.Enums;
using Cataloguer.DomainLogic.Interfaces.Models.Search;
using Cataloguer.UI.Extensions;
using System;
using System.Windows.Forms;

namespace Cataloguer.UI.FormControls.Search
{
    public class SearchFormControl<T> : FormControl<SearchComparison<T>>
    {
        private readonly FormControl<T> _baseControl;
        private readonly SearchComparison<T> _comparison = new SearchComparison<T>();

        private ComboBox _comboBox;

        public override SearchComparison<T> Value
        {
            get
            {
                _comparison.Comparison = ((ComparisonItem)_comboBox.SelectedItem).Comparison;
                _comparison.Object = _baseControl.Value;

                return _comparison;
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

        public SearchFormControl(FormControl<T> baseControl)
        {
            _baseControl = baseControl;
        }

        protected override Control CreateControl()
        {
            Control control = _baseControl.Control;

            Control firstControl = control.Controls[0];
            Control secondControl = control.Controls[1];

            _comboBox = new ComboBox
            {
                Location = Offset(firstControl, 3, 3),
                Width = 37,
                DropDownStyle = ComboBoxStyle.DropDownList,
            };
            _comboBox.Items.AddRange(GetComparisonItems());
            _comboBox.SelectedIndex = 0;

            secondControl.Location = Offset(_comboBox, 5, 0, horizontal: true);

            return control
                .With(_comboBox);
        }

        private ComparisonItem[] GetComparisonItems()
        {
            return new[]
            {
                new ComparisonItem { Comparison = Comparison.None, Display = " " },
                new ComparisonItem { Comparison = Comparison.MoreThan, Display = ">" },
                new ComparisonItem { Comparison = Comparison.Equal, Display = "=" },
                new ComparisonItem { Comparison = Comparison.LessThan, Display = "<" },
            };
        }
    }
}
