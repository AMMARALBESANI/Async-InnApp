using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace HotelAppDemo.Model.services
{
    public class jwtTokenServices
    {

        private SignInManager<ApplicationUser> signInManager;
        private IConfiguration configuration;

        public jwtTokenServices( IConfiguration config , SignInManager<ApplicationUser> manager)
        {
             configuration = config;
              signInManager = manager;
            
        }
        public static TokenValidationParameters GetValidationParameters(IConfiguration configuration)
        {
            return new TokenValidationParameters
            {
               ValidateIssuerSigningKey = true,
               IssuerSigningKey=GetSecurityKey(configuration),
               ValidateIssuer=false,
               ValidateAudience=false

            };
            
               
        }

      private static SecurityKey GetSecurityKey (IConfiguration configuration) 
        {

            var Secret = configuration["JWT:Secret"];
            if (Secret == null)
            {
                throw new InvalidOperationException("JWT:secret key is not exist");
            }



            var secretBytes = Encoding.UTF8.GetBytes(Secret);

            return new SymmetricSecurityKey(secretBytes);
        }

        public async Task<string> GetToken(ApplicationUser User , TimeSpan expiresIn)
        {
            var Principle = await signInManager.CreateUserPrincipalAsync(User);

            if ( Principle == null)
            {
                return null;
            }

            var signinkey = GetSecurityKey(configuration);

            var token = new JwtSecurityToken
                (
                  expires:DateTime.UtcNow+expiresIn,
                  signingCredentials:new SigningCredentials(signinkey, SecurityAlgorithms.HmacSha256),
                  claims:Principle.Claims
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
            
        }
    }

}

