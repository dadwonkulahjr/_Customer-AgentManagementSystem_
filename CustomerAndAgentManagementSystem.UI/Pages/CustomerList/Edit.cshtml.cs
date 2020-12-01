using System.Threading.Tasks;
using CustomerAndAgentManagementSystem.Models;
using CustomerAndAgentManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CustomerAndAgentManagementSystem.UI.Pages.CustomerList
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICustomerStore _repository;
        [BindProperty]
        public Customer Customer { get; set; }
        public EditModel(AppDbContext appDbContext, ICustomerStore repository)
        {
            _appDbContext = appDbContext;
            _repository = repository;
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
            ViewData["AgentId"] = new SelectList(_appDbContext.Agents, "AgentId", "GetFullName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.UpdateCustomer(Customer);
            return RedirectToPage("Index");
        }
    }
}
