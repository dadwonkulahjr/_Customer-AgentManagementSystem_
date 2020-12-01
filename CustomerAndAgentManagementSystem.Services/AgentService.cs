using CustomerAndAgentManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerAndAgentManagementSystem.Services
{
    public class AgentService : IAgentStore
    {
        private readonly AppDbContext _appDbContext;

        public AgentService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Agent> Create(Agent newAgent)
        {
            var result = await _appDbContext.Agents.AddAsync(newAgent);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;

        }
        public async Task<Agent> DeleteExistingAgent(int id)
        {
            Agent findAgent = await _appDbContext.Agents.FindAsync(id);
            if (findAgent != null)
            {
                _appDbContext.Agents.Remove(findAgent);
                try
                {
                    await _appDbContext.SaveChangesAsync();
                }
                catch (System.Exception)
                {
                    return null;
                }

                return findAgent;
            }
            return null;
        }
        public async Task<Agent> GetAgentById(int id)
        {
            return await _appDbContext.Agents.FindAsync(id);
        }
        public async Task<IEnumerable<Agent>> GetAllAgents()
        {
            return await _appDbContext.Agents
                //.Include(c => c.Customer)
                .ToListAsync();
        }
        public async Task<Agent> UpdateAgent(Agent agentChanges)
        {
            var updateAgent = _appDbContext.Agents.Attach(agentChanges);
            updateAgent.State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return agentChanges;
        }
    }
}
