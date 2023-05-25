using Microsoft.EntityFrameworkCore;
using weeCompanyBackend.Domain.Models;

namespace weeCompanyBackend.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contact { get; set; }
    }
}
