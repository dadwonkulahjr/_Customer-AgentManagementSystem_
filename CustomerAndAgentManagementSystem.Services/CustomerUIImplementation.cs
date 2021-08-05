using CustomerAndAgentManagementSystem.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAndAgentManagementSystem.Services
{
    public class CustomerUIImplementation : ICustomerUI
    {
        private readonly HttpClient _httpClient;
        public CustomerUIImplementation(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Customer> CreateCustomer(Customer newCustomer)
        {
            return await _httpClient.PostJsonAsync<Customer>("api/customers", newCustomer);
        }
        public async Task DeleteCustomer(int id)
        {
            await _httpClient.DeleteAsync($"api/customers/{id}");
        }
        public async Task<Customer> GetCustomerId(int id)
        {
            return await _httpClient.GetJsonAsync<Customer>($"api/customers/{id}");
        }
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _httpClient.GetJsonAsync<Customer[]>("api/customers");
        }
        public async Task<Customer> UpdateEmployee(Customer updatedCustomer)
        {
            return await _httpClient.PutJsonAsync<Customer>("api/customers", updatedCustomer);
        }
    }
}
