using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using static Proyecto_Evento.MyContext.MyContext;

namespace Proyecto_Evento.MyContext
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<EventUser> EventUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Relation Role and User

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId);

            //Relation State and User

            modelBuilder.Entity<State>()
                .HasMany(s => s.Users)
                .WithOne(u => u.State) 
                .HasForeignKey(u => u.StateId);

            //Relation EventUser

            modelBuilder.Entity<EventUser>()
                .HasKey(eu => eu.EventUserId);

            modelBuilder.Entity<EventUser>()
                .HasOne(eu => eu.Event)
                .WithMany(e => e.EventUsers)
                .HasForeignKey(eu => eu.EventId);

            modelBuilder.Entity<EventUser>()
                .HasOne(eu => eu.User)
                .WithMany(u => u.EventUsers)
                .HasForeignKey(eu => eu.UserId);
        }

    }
}
