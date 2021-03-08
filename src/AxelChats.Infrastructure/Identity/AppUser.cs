using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace AxelChats.Infrastructure.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public List<RefreshSession> RefreshSessions { get; init; } = new();
    }
}
