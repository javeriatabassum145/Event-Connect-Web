using System.ComponentModel.DataAnnotations;

namespace Event_Connect_Web.Models
{
    public class User
    {
        public int? UserID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
    }
}
