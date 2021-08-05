using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CustomerAndAgentManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CustomerAndAgentManagementSystem.UI.Pages.CustomerList
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _repository;
        public List<Customer> Customers { get; set; }
        public IndexModel(AppDbContext repository)
        {
            _repository = repository;
        }
        public async Task OnGet()
        {
            Customers = await _repository.Customers
                                .Include(c => c.Agent)
                                .ToListAsync();
                               
        }

    }

}