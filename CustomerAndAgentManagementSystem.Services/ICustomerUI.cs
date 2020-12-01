using CustomerAndAgentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerAndAgentManagementSystem.Services
{
    public interface ICustomerUI
    {
        Task<Customer> CreateCustomer(Customer newCustomer);
        Task DeleteCustomer(int id);
        Task<Customer> GetCustomerId(int id);
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> UpdateEmployee(Customer updatedCustomer);
    }
}
