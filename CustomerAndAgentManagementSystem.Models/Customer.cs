
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomerAndAgentManagementSystem.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [Display(Name = "Last name")]
        [RegularExpression(pattern: @"^[A-Z]+[a-zA-Z]*$", ErrorMessage ="Please enter a valid lastname, note. the first letter of the customer name should start with uppercase character.")]
        public string CustomerLastName { get; set; }
        [Required]
        [Display(Name = "First name")]
        [RegularExpression(pattern: @"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "Please enter a valid firstname, note. the first letter of the customer name should start with uppercase character.")]
        public string CustomerFirstName { get; set; }
        [EmailAddress(ErrorMessage ="Please enter a valid email.")]
        [Display(Name = "Email")]
        [Required]
        public string CustomerEmail { get; set; }
        [Display(Name ="Agent")]
        [Required(ErrorMessage = "Agent is mandatory!")]
        public int? AgentId { get; set; }
        public virtual Agent Agent { get; set; }
        public virtual string GetCustomerFullName
        {
            get { return CustomerFirstName + ", " + CustomerLastName; }
        }


    }
}
