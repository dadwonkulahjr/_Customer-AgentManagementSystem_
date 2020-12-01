using CustomerAndAgentManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CustomerAndAgentManagementSystem.Services
{
    public class CustomerService : ICustomerStore
    {
        private readonly AppDbContext _appDbContext;

        public CustomerService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Customer> Create(Customer newCustomer)
        {
            var result = await _appDbContext.Customers.AddAsync(newCustomer);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Customer> DeleteExistingCustomer(int id)
        {
            Customer findCustomer = await _appDbContext.Customers.FindAsync(id);
            if (findCustomer != null)
            {
                _appDbContext.Customers.Remove(findCustomer);
                await _appDbContext.SaveChangesAsync();
                return findCustomer;
            }
            return null;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _appDbContext.Customers
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _appDbContext.Customers.FindAsync(id);
        }

        public async Task<Customer> UpdateCustomer(Customer customerChanges)
        {
            var updateCustomer = _appDbContext.Customers.Attach(customerChanges);
            updateCustomer.State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return customerChanges;
        }
    }
}
