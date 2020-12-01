using System.Threading.Tasks;
using CustomerAndAgentManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CustomerAndAgentManagementSystem.UI.Pages.CustomerList
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _appDbContext;
        public Customer Customer { get; set; }
        public DetailsModel(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/CustomerNotFound");
            }
            Customer = await _appDbContext.Customers
                            .Include(c => c.Agent)
                            .FirstOrDefaultAsync(c => c.CustomerId == id);
            if (Customer == null)
            {
                return RedirectToPage("/CustomerNotFound");
            }

            return Page();
        }
    }

}
