using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerAndAgentManagementSystem.UI.Pages
{
    public class CustomErrorModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
