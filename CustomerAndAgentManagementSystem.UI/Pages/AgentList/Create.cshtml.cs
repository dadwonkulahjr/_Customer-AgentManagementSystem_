using CustomerAndAgentManagementSystem.Models;
using CustomerAndAgentManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CustomerAndAgentManagementSystem.UI.Pages.AgentList
{
    public class CreateModel : PageModel
    {
        private readonly IAgentStore _repository;
        [BindProperty]
        public Agent Agent { get; set; }
        public CreateModel(IAgentStore repository)
        {
            _repository = repository;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.Create(Agent);
            return RedirectToPage("Index");

        }
    }
}
