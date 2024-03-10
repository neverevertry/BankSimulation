using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Card> card { get; set; }

        public DbSet<Operation> operation { get; set; }

        public DbSet<DescriptionOperation> description { get; set; }
    }
}
