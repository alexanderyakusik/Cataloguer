using System.Collections.Generic;
using System.Linq;
using Cataloguer.DomainLogic.Interfaces.Models.BaseClasses;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.UI.FormControls.Dropdown;

namespace Cataloguer.UI.Providers.Dropdown
{
    public class NamedBaseDropdownValuesProvider<T> : DropdownValuesProvider<T> where T : NamedBaseModel
    {
        public NamedBaseDropdownValuesProvider(ICrudService<T> service) : base(service)
        {
        }

        public override IEnumerable<DropdownValue> GetValues()
        {
            return Service
                .GetAll()
                .Select(item => new DropdownValue
                {
                    Key = item.Id,
                    Value = item.Name,
                });
        }
    }
}
