using CyclistMembershipApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CyclistMembershipApplication.Data
{
    public class ClubMembershipDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host = localhost; Port = 5432; Database = cyclistdata; Username = postgres; Password = 4526");
            base.OnConfiguring(optionsBuilder);
        }
        DbSet<User> users{get; set;}
    }
}