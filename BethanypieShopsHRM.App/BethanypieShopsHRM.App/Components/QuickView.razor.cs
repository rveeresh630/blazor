using BethanysPieShopHRM.Shared.Domain;

using Microsoft.AspNetCore.Components;

namespace BethanypieShopsHRM.App.Components
{
    public partial class QuickView
    {
        [Parameter]
        public Employee? Employee { get; set; } = default!;

        public Employee? _employee;

        protected override void OnParametersSet()
        {
            _employee=Employee;
        }

        public void Close()
        {
            _employee = null;
        }
    }
}
