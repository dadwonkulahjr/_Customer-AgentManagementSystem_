using System;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace CustomerAndAgentManagementSystem.UI.Pages
{
    public class IndexModel : PageModel
    {
        public string CurrentDateCheck { get; set; }
        public void OnGet()
        {
            CurrentDateCheck = DateTime.Today.ToLongDateString();
        }
    }
}
