using CustomerAndAgentManagementSystem.Models;
using CustomerAndAgentManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerAndAgentManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly IAgentStore _repository;

        public AgentsController(IAgentStore repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAgentList()
        {
            try
            {
                return Ok(await _repository.GetAllAgents());

            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "There were error in retrieving the data from the database!");
            }
        }

        [HttpGet(template: "{id:int}")]
        public async Task<ActionResult> GetAgent(int id)
        {
            try
            {
                var result = await _repository.GetAgentById(id);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "There were error in retrieving the data from the database!");
            }
        }
        [HttpPost]
        public async Task<ActionResult> CreateNewAgent(Agent agent)
        {
            try
            {
                if (agent == null)
                {
                    return BadRequest();
                }
                var agentCreated = await _repository.Create(agent);
                return CreatedAtAction(nameof(GetAgent), new { id = agentCreated.AgentId }, agentCreated);

            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "There were error in createing new customer, Please contact your admin!");
            }
        }

        [HttpPut()]
        public async Task<ActionResult> UpdateAgent(Agent agent)
        {
            try
            {

                var getAgent = await _repository.GetAgentById(agent.AgentId);
                if (getAgent != null)
                {
                    return Ok(await _repository.UpdateAgent(agent));
                }
                else
                {
                    return NotFound($"Agent with Id = {agent.AgentId} not found");
                }
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "There were error in updating the data from the database!");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAgent(int id)
        {
            try
            {
                var agentToDelete = await _repository.GetAgentById(id);
                if (agentToDelete == null)
                {
                    return NotFound($"Agent with Id = {id} not found");
                }

                return Ok(await _repository.DeleteExistingAgent(id));

            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "There were error in deleting the data from the database!");

            }
        }
    }
}
