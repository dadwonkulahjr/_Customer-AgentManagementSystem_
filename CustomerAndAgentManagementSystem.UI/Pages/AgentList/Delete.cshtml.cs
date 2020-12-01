using System.Threading.Tasks;
using CustomerAndAgentManagementSystem.Models;
using CustomerAndAgentManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerAndAgentManagementSystem.UI.Pages.AgentList
{
    public class DeleteModel : PageModel
    {
        private readonly IAgentStore _repository;
        public bool ShowModal { get; set; } = true;
        [BindProperty]
        public Agent Agent { get; set; }
        public DeleteModel(IAgentStore repository)
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
        public async Task<IActionResult> OnPostCheckDeleteAsync(int? id)
        {
            Agent = await _repository.GetAgentById(id.Value);
            if (Agent == null)
            {
                return RedirectToPage("/AgentNotFound");
            }
            ShowModal = false;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
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
            Agent agent = await _repository.DeleteExistingAgent(Agent.AgentId);
            if(agent == null)
            {
                return RedirectToPage("/DatabaseError");
            }
            return RedirectToPage("Index");
        }
    }
}
