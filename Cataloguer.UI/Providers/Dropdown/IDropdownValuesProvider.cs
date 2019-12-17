using Cataloguer.UI.FormControls.Dropdown;
using System.Collections.Generic;

namespace Cataloguer.UI.Providers.Dropdown
{
    public interface IDropdownValuesProvider
    {
        IEnumerable<DropdownValue> GetValues();
    }
}
