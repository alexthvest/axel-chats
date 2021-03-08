using AxelChats.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AxelChats.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Account> Accounts => Set<Account>();
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    }
}
