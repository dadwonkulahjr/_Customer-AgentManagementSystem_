using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerAndAgentManagementSystem.Models;
using CustomerAndAgentManagementSystem.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerAndAgentManagementSystem.UI.Pages.AgentList
{
    public class IndexModel : PageModel
    {
        private readonly IAgentStore _repository;
        public IEnumerable<Agent> Agents { get; set; }
        public IndexModel(IAgentStore repository)
        {
            _repository = repository;
        }
        public async Task OnGet()
        {
            Agents = (await _repository.GetAllAgents()).ToList();
        }
    }
}
