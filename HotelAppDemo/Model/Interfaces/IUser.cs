using HotelAppDemo.Model.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HotelAppDemo.Model.Interfaces
{
    public interface IUser
    {
        public Task<UserDTO> Register(RegisterUserDTO registerUserdto , ModelStateDictionary modelstate);
        public Task<UserDTO> Authenticate( string userName , string password);
        

        
    }
}
