using CustomerAndAgentManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CustomerAndAgentManagementSystem.UI.Pages.CustomerList
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _repository;
        public IEnumerable<Customer> Customers { get; set; }
        public IndexModel(AppDbContext repository)
        {
            _repository = repository;
        }
        public async Task OnGet()
        {
            Customers = await _repository.Customers
                                .Include(c => c.Agent)
                                .ToListAsync();
        }
    }
}
