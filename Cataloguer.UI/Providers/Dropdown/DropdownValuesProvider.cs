using Cataloguer.DomainLogic.Interfaces.Models.BaseClasses;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.UI.FormControls.Dropdown;
using System.Collections.Generic;

namespace Cataloguer.UI.Providers.Dropdown
{
    public abstract class DropdownValuesProvider<T> where T : BaseModel
    {
        protected ICrudService<T> Service { get; }

        protected DropdownValuesProvider(
            ICrudService<T> service
        )
        {
            Service = service;
        }

        public abstract IEnumerable<DropdownValue> GetValues();
    }
}
