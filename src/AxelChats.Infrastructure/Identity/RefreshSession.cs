using System;
using AxelChats.Domain.Entities;

namespace AxelChats.Infrastructure.Identity
{
    public record RefreshSession : Entity
    {
        public AppUser User { get; init; }
        
        public string Token { get; init; }
        
        public DateTime ExpiresAt { get; init; }
        
        public bool IsRevoked { get; private set; }

        public bool IsExpired => DateTime.UtcNow >= ExpiresAt;

        public bool IsActive => !IsRevoked && !IsExpired;

        public void Revoke()
        {
            IsRevoked = true;
        }
    }
}
