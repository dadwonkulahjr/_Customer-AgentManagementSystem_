using CustomerAndAgentManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerAndAgentManagementSystem.Services
{
    public interface ICustomerStore
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> UpdateCustomer(Customer customerChanges);
        Task<Customer> Create(Customer newCustomer);
        Task<Customer> GetCustomerById(int id);
        Task<Customer> DeleteExistingCustomer(int id);
    }
}
