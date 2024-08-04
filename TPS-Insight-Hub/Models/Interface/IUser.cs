
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TPS_Insight_Hub.Models.DTO;


namespace TPS_Insight_Hub.Models.Interface
{
    public interface IUser
    {
        public Task<UserDTO> Register(RegisterUserDTO registered, ModelStateDictionary modelstate);
        public Task<bool> DeleteUser(string userId);
        public Task<UserDTO> Authenticate(string UserName, string Password);
        public Task<UserDTO> GetUser(ClaimsPrincipal principal);
        public Task<List<UserListDTO>> GetAllUsers();

    }
}
