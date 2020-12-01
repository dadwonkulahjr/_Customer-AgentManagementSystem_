using CustomerAndAgentManagementSystem.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerAndAgentManagementSystem.Services
{
    public class AgentUIImplementation : IAgentUI
    {
        private readonly HttpClient _httpClient;

        public AgentUIImplementation(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Agent> CreateAgent(Agent newAgent)
        {
            return await _httpClient.PostJsonAsync<Agent>("api/agents", newAgent);
        }

        public async Task DeleteAgent(int id)
        {
            await _httpClient.DeleteAsync($"api/agents/{id}");
        }

        public async Task<Agent> GetAgentId(int id)
        {
            return await _httpClient.GetJsonAsync<Agent>($"api/agents/{id}");
        }

        public async Task<IEnumerable<Agent>> GetAgents()
        {
            return await _httpClient.GetJsonAsync<Agent[]>("api/agents");
        }

        public async Task<Agent> UpdateAgent(Agent updatedAgent)
        {
            return await _httpClient.PutJsonAsync<Agent>("api/agents", updatedAgent);
        }

    }
}