using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AxelChats.Infrastructure.Auth
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        
        public string Audience { get; set; }
        
        public string SecretKey { get; set; }

        public int AccessTokenLifeTime { get; set; }

        public SymmetricSecurityKey SymmetricSecurityKey => new(Encoding.ASCII.GetBytes(SecretKey));
    }
}
