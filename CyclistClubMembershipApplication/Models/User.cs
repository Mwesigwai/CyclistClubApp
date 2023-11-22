using System.ComponentModel.DataAnnotations.Schema;

namespace CyclistMembershipApplication.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string?  FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public String? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}