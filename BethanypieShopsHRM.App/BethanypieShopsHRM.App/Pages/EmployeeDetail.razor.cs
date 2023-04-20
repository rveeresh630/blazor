using BethanyPieShopHRM.App.Models;

using BethanysPieShopHRM.App.Services;
using BethanysPieShopHRM.Shared.Domain;
using BethanysPieShopHRM.Shared.Marker;

using Microsoft.AspNetCore.Components;

namespace BethanypieShopsHRM.App.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter]
        public string EmployeeId { get; set; }

        public Employee? Employee { get; set; } = new Employee();

        public List<Marker> MapMarkers { get; set; } = new List<Marker>();

        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }

        //protected override Task OnInitializedAsync()
        //{
        //    Employee=MockDataService.Employees.FirstOrDefault(x=> x.EmployeeId== int.Parse(EmployeeId));
        //    return base.OnInitializedAsync();
        //}

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            if (Employee.Longitude.HasValue && Employee.Latitude.HasValue)
            {
                MapMarkers = new List<Marker>
            {
                new Marker{Description = $"{Employee.FirstName} {Employee.LastName}",  ShowPopup = false, X = Employee.Longitude.Value, Y = Employee.Latitude.Value}
            };
            }

        }
    }
}
