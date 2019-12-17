using System.Collections.Generic;
using System.Linq;
using Cataloguer.DomainLogic.Interfaces.Services;
using Cataloguer.Infrastructure.Mapping;
using Cataloguer.UI.FormControls.Dropdown;
using Cataloguer.UI.ViewModels;

namespace Cataloguer.UI.Providers.Dropdown
{
    public class CompanyDropdownProvider : IDropdownValuesProvider
    {
        private readonly ICompanyService _service;
        private readonly Mapper _mapper;

        public CompanyDropdownProvider(ICompanyService service, Mapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IEnumerable<DropdownValue> GetValues()
        {
            return _service
                .GetAll()
                .Select(item =>
                {
                    var viewModel = _mapper.Map<CompanyViewModel>(item);

                    return new DropdownValue
                    {
                        Key = viewModel.Id,
                        Value = viewModel.Name,
                    };
                });
        }
    }
}
