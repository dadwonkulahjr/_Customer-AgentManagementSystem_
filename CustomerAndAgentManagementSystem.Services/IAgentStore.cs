using CustomerAndAgentManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerAndAgentManagementSystem.Services
{
    public interface IAgentStore
    {
        Task<IEnumerable<Agent>> GetAllAgents();
        Task<Agent> UpdateAgent(Agent agentChanges);
        Task<Agent> Create(Agent newAgent);
        Task<Agent> GetAgentById(int id);
        Task<Agent> DeleteExistingAgent(int id);
    }
}
