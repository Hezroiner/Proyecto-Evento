using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Proyecto_Evento.MyDbContext
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventUser> EventUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User - State relationship
            modelBuilder.Entity<User>()
                .HasOne(user => user.State)
                .WithMany(state => state.Users)
                .HasForeignKey(user => user.StateId);

            // User - Role relationship
            modelBuilder.Entity<User>()
                .HasOne(user => user.Role)
                .WithMany(role => role.Users)
                .HasForeignKey(user => user.RoleId);

            // EventUser - Event relationship
            modelBuilder.Entity<EventUser>()
                .HasOne(eventUser => eventUser.Event)
                .WithMany(eventObj => eventObj.EventUsers)
                .HasForeignKey(eventUser => eventUser.EventId);

            // EventUser - User relationship
            modelBuilder.Entity<EventUser>()
                .HasOne(eventUser => eventUser.User)
                .WithMany(user => user.EventUsers)
                .HasForeignKey(eventUser => eventUser.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
