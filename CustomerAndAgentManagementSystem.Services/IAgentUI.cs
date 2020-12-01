using CustomerAndAgentManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerAndAgentManagementSystem.Services
{
    public interface IAgentUI
    {
        Task<Agent> CreateAgent(Agent newCustomer);
        Task DeleteAgent(int id);
        Task<Agent> GetAgentId(int id);
        Task<IEnumerable<Agent>> GetAgents();
        Task<Agent> UpdateAgent(Agent updatedAgent);
    }
}
