using CustomerAndAgentManagementSystem.Models;
using CustomerAndAgentManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerAndAgentManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerStore _repository;
        public CustomersController(ICustomerStore repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult> GetCustomerList()
        {
            try
            {
                return Ok(await _repository.GetAllCustomers());

            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "There were error in retrieving the data from the database!");
            }
        }

        [HttpGet(template:"{id:int}")]
        public async Task<ActionResult> GetCustomer(int id)
        {
            try
            {
                var result = await _repository.GetCustomerById(id);
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
        public async Task<ActionResult> CreateNewCustomer(Customer customer)
        {
            try
            {
                if(customer == null)
                {
                    return BadRequest();
                }
                var customerCreated = await _repository.Create(customer);
                return CreatedAtAction(nameof(GetCustomer), new { id = customerCreated.CustomerId }, customerCreated);

            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "There were error in createing new customer, Please contact your admin!");
            }
        }
        [HttpPut()]
        public async Task<ActionResult> UpdateCustomer(Customer customer)
        {
            try
            {

                var getCustomer = await _repository.GetCustomerById(customer.CustomerId);
                if (getCustomer != null)
                {
                    return Ok(await _repository.UpdateCustomer(customer));
                }
                else
                {
                    return NotFound($"Customer with Id = {customer.CustomerId} not found");
                }
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "There were error in updating the data from the database!");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            try
            {
                var customerToDelete = await _repository.GetCustomerById(id);
                if (customerToDelete == null)
                {
                    return NotFound($"Customer with Id = {id} not found");
                }

                return Ok(await _repository.DeleteExistingCustomer(id));

            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "There were error in deleting the data from the database!");

            }
        }
    }
}
