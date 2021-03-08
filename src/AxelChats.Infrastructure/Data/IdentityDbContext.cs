using System;
using AxelChats.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AxelChats.Infrastructure.Data
{
    public class IdentityDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DbSet<RefreshSession> RefreshSessions => Set<RefreshSession>();
        
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) {}
    }
}
