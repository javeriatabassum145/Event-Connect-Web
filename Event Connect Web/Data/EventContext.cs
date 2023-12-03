using Event_Connect_Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Event_Connect_Web.Data
{
    public class EventContext : IdentityDbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options) {  }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Event> Event { get;set;}
        public DbSet<EventManager> EventManager { get; set; }
        public DbSet<User> User { get; set; }

    }
}
