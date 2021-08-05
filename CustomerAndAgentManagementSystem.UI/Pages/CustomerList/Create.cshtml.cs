using CustomerAndAgentManagementSystem.Models;
using CustomerAndAgentManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace CustomerAndAgentManagementSystem.UI.Pages.CustomerList
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _repository;
        private readonly ICustomerStore _customerStoreRepository;
        public CreateModel(AppDbContext repository, ICustomerStore customerStoreRepository)
        {
            _repository = repository;
            _customerStoreRepository = customerStoreRepository;
        }
        [BindProperty]
        public Customer Customer { get; set; }
        public IActionResult OnGet()
        {
            ViewData["AgentId"] = new SelectList(_repository.Agents, "AgentId", "GetFullName");
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _customerStoreRepository.Create(Customer);
            return RedirectToPage("Index");
        }
    }
}
