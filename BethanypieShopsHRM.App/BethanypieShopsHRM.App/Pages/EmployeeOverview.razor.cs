using BethanyPieShopHRM.App.Models;

using BethanysPieShopHRM.App.Services;
using BethanysPieShopHRM.Shared.Domain;

using Microsoft.AspNetCore.Components;

namespace BethanypieShopsHRM.App.Pages
{
    public partial class EmployeeOverview
    {
        //[Inject]

        //public HttpClient HttpClient { get; set; }

        public List<Employee> Employees { get; set; } = default!;

        private Employee? _selectedEmployee;

        //protected override void OnInitialized()
        //{
        //    Employees= MockDataService.Employees.ToList();
        //}

        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
            //Employees= MockDataService.Employees.ToList();
        }

        public  void ShowClickViewPopup( Employee selectedEmployee)
        {
            _selectedEmployee = selectedEmployee;
        }
    }
}
