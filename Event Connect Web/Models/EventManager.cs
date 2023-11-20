using System.ComponentModel.DataAnnotations;

namespace Event_Connect_Web.Models
{
    public class EventManager
    {
        [Required]
        public int EventManagerID { get; set; }
        public List<Event>? Events { get; set; }
    }
}
