using HotelAppDemo.Model.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace HotelAppDemo.Model.Interfaces
{
    public interface IUser
    {
        public Task<UserDTO> Register(RegisterUserDTO registerUserdto , ModelStateDictionary modelstate);
        public Task<UserDTO> Authenticate( string userName , string password);

        public Task<UserDTO> GetUser(ClaimsPrincipal principal);
        

        
    }
}
