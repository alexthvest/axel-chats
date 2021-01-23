using System.Collections.Generic;
using System.Security.Claims;

namespace AxelChats.Infrastructure.Auth
{
    public interface IJwtFactory
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
    }
}
