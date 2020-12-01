using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerAndAgentManagementSystem.Models
{
    public class Agent
    {
        public Agent()
        {
            Customer = new HashSet<Customer>();
        }
        [Key]
        public int AgentId { get; set; }
        [Required, Column("Agent First name", TypeName = "nvarchar(50)")]
        [Display(Name ="Agent First name")]
        [RegularExpression(pattern: @"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "Please enter a valid firstname, note. the first letter of the agent name should start with uppercase character.")]
        public string AgentFirstName { get; set; }
        [Required, Column("Agent Last name", TypeName = "nvarchar(50)")]
        [Display(Name ="Agent Last name")]
        [RegularExpression(pattern: @"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "Please enter a valid lastname, note. the first letter of the agent name should start with uppercase character.")]
        public string AgentLastName { get; set; }
        [Column("Agent Email", TypeName = "nvarchar(50)")]
        [EmailAddress(ErrorMessage ="Please enter a valid email")]
        [Required]
        [Display(Name ="Agent Email")]
        public string AgentEmail { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        [Display(Name ="Agent Fullname")]
        public virtual string GetFullName
        {
            get { return AgentFirstName + ", " + AgentLastName; }
        }
    }
}
