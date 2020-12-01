using System.Threading.Tasks;
using CustomerAndAgentManagementSystem.Models;
using CustomerAndAgentManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CustomerAndAgentManagementSystem.UI.Pages.CustomerList
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICustomerStore _repository;
        public bool ShowModal { get; set; } = true;
        [BindProperty]
        public Customer Customer { get; set; }
        public DeleteModel(AppDbContext appDbContext, ICustomerStore repository)
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
                .Include(c => c.Agent).FirstOrDefaultAsync(c => c.CustomerId == id);

            if (Customer == null)
            {
                return RedirectToPage("/DefaultNotFound");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostCheckDeleteAsync(int? id)
        {
            Customer = await _appDbContext.Customers
               .Include(c => c.Agent).FirstOrDefaultAsync(c => c.CustomerId == id);

            if (Customer == null)
            {
                return RedirectToPage("/CustomerNotFound");
            }
            ShowModal = false;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/CustomerNotFound");
            }

            Customer = await _appDbContext.Customers.FindAsync(id);

            if (Customer != null)
            {
                await _repository.DeleteExistingCustomer(id.Value);
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage("/CustomerNotFound");
            }
        }

       

    }
}
