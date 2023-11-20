using Event_Connect_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Event_Connect_Web.Data
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options) { }

        public DbSet<Event> Event { get;set;}
        public DbSet<EventManager> EventManager { get; set; }
        public DbSet<User> User { get; set; }

    }
}
