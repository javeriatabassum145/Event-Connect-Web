using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml;
using System.ComponentModel.DataAnnotations;

namespace Event_Connect_Web.Models
{
    public class Event
    {
        [Required]
        public int EventID { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string? Location { get; set; }
        [Required]
        public User? Organizer { get; set; }
        public List<User>? Attendees { get; set; }
    }
}
