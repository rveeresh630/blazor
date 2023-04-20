using BethanyPieShopHRM.App.Models;

using BethanysPieShopHRM.App.Services;
using BethanysPieShopHRM.Shared.Domain;

using Microsoft.AspNetCore.Components;

using System.Reflection.Metadata;

namespace BethanypieShopsHRM.App.Components.Widgets
{
    public partial class EmployeeCountWidget
    {
        public int EmployeeCounter { get; set; }

        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }

        protected async override Task OnInitializedAsync()
        {

          //  EmployeeCounter = MockDataService.Employees.Count;
            // var employees=  EmployeeDataService.GetAllEmployees();
            // EmployeeCounter = employees.Result.Count();
            var employees = (await EmployeeDataService.GetAllEmployees()).ToList();
            EmployeeCounter = employees.Count();
        }
    }
}
