using System.ComponentModel.DataAnnotations;

namespace Event_Connect_Web.Models
{
    public class Login
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
