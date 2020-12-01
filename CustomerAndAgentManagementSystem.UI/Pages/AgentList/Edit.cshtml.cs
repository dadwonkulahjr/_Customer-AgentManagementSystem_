using System.Threading.Tasks;
using CustomerAndAgentManagementSystem.Models;
using CustomerAndAgentManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerAndAgentManagementSystem.UI.Pages.AgentList
{
    public class EditModel : PageModel
    {
        private readonly IAgentStore _repository;
        [BindProperty]
        public Agent Agent { get; set; }
        public EditModel(IAgentStore repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/AgentNotFound");
            }

            Agent = await _repository.GetAgentById(id.Value);

            if (Agent == null)
            {
                return RedirectToPage("/AgentNotFound");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.UpdateAgent(Agent);
            return RedirectToPage("Index");
        }

    }
}
