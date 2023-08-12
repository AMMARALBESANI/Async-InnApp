using HotelAppDemo.Model.DTO;
using HotelAppDemo.Model.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelAppDemo.Model.services
{
    public class IdentityUserService : IUser
    {
        private UserManager<ApplicationUser> userManager;
        private jwtTokenServices tokenServices;

        public IdentityUserService(UserManager<ApplicationUser> manager , jwtTokenServices tokenServices)
        {
            userManager = manager;
            this.tokenServices = tokenServices;
        }



        public async Task<UserDTO> Authenticate(string userName, string password)
        {
            var user = await userManager.FindByNameAsync(userName);
            bool validPassword = await userManager.CheckPasswordAsync(user,password);
            if (validPassword)
            {
                return new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Token= await tokenServices.GetToken(user,System.TimeSpan.FromMinutes(5))

                };
            }
            return null;
        }

        public async Task<UserDTO> GetUser(ClaimsPrincipal principal)
        {
            var user = await userManager.GetUserAsync(principal);

            return new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Token = await tokenServices.GetToken(user, System.TimeSpan.FromMinutes(5))

            };
        }

        public async Task<UserDTO> Register(RegisterUserDTO registerUserdto, ModelStateDictionary modelstate)
        {
            var user = new ApplicationUser()
            {
                UserName = registerUserdto.UserName,
                Email = registerUserdto.Email,
                PhoneNumber = registerUserdto.PhoneNumber
            };
            var result = await userManager.CreateAsync(user , registerUserdto.Password);

            if (result.Succeeded)
            {

                userManager.AddToRolesAsync(user , registerUserdto.Roles);
                return new UserDTO
                {
                    Id=user.Id,
                    UserName = user.UserName,
                    Token = await tokenServices.GetToken(user, System.TimeSpan.FromMinutes(5)),
                    Roles = await userManager.GetRolesAsync(user)
                };
            }

            foreach (var error in result.Errors)
            {
                var errorKey =
                error.Code.Contains("Password") ? nameof(registerUserdto.Password) :
                error.Code.Contains("Email") ? nameof(registerUserdto.Email) :
                    error.Code.Contains("UserName") ? nameof(registerUserdto.UserName) :
                    "";
                modelstate.AddModelError(errorKey, error.Description);
            };
            return null;
        }
    }
}
