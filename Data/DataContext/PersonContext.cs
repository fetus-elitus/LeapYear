using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.EntityModels;

namespace Data.DataContext
{
    public class PersonContext : IdentityDbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options) { }
        public DbSet<Person> People { get; set; }
    }
}
