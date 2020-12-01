using CustomerAndAgentManagementSystem.Models;
using CustomerAndAgentManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CustomerAndAgentManagementSystem.UI.Pages.AgentList
{
    public class DetailsModel : PageModel
    {
        private readonly IAgentStore _repository;
        [BindProperty]
        public Agent Agent { get; set; }
        public DetailsModel(IAgentStore repository)
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
    }
}
