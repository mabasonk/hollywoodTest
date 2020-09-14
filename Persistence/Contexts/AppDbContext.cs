using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HollywoodTest.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace HollywoodTest.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventDetail> EventDetails { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
             base.OnModelCreating(builder);

             builder.Entity<Tournament>().HasKey(t => t.Id);
             builder.Entity<Tournament>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();

             builder.Entity<Tournament>().HasData
             (
                 new Tournament {Id = 001, Name = "Test tournament"}
             );

             builder.Entity<Event>().HasKey(e => e.Id);
             builder.Entity<Event>().Property(e => e.Name).HasMaxLength(100);


             builder.Entity<Event>().HasData(
                 new Event
                 {
                     Id = 101,
                     Name = "Test Event",
                     EventNumber = 1,
                     EventDate = new DateTime(2020, 09,09, 01 ,00, 00),
                     EventEndDate = new DateTime(2020, 09, 10, 01, 00, 00),
                     AutoClose = true,
                     TournamentId = 001
                 }
             );


        }
    }
}
