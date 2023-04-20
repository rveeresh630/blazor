﻿using BethanysPieShopHRM.Shared.Domain;

using Microsoft.AspNetCore.Components;

namespace BethanypieShopsHRM.App.Components
{
    public partial class EmployeeCard
    {
        [Parameter]
        public Employee Employee { get; set; } = default!;

        [Parameter]
        public EventCallback<Employee> EmployeeQuickViewClicked { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        protected override void OnInitialized()
        {
            if(string.IsNullOrEmpty(Employee.LastName))
            {
                throw new Exception("Last name can't be empty");
            }
        }

        public void NavigateToDetails(Employee selectedemployee)
        {
            NavigationManager.NavigateTo($"/employeedetail/{selectedemployee.EmployeeId}");
        }
    }
}