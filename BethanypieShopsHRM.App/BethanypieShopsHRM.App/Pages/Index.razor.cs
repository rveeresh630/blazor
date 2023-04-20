using BethanypieShopsHRM.App.Components.Widgets;
using BethanypieShopHRM.App.Services;

using System.Runtime.CompilerServices;

namespace BethanypieShopsHRM.App.Pages
{
    public partial class Index
    {
        public List<Type> Widgets { get; set; } = new List<Type>() { typeof(EmployeeCountWidget), typeof(InboxWidget) };
    }
}
