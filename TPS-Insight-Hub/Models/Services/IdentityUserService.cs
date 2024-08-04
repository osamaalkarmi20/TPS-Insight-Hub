
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TPS_Insight_Hub.Models;
using Microsoft.EntityFrameworkCore;
using TPS_Insight_Hub.Models.Interface;
using TPS_Insight_Hub.Models.DTO;

namespace TPS_Insight_Hub
{
    public class IdentityUserService : IUser
    {
        private readonly UserManager<ApplicationUser> _manager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly HubDbContext _context;
        public IdentityUserService(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager, HubDbContext context)
        {

            _manager = userManager;
            _signInManager = signInManager;
            _context = context;
  
        }

        public async Task<UserDTO> Register(RegisterUserDTO registered, ModelStateDictionary modelstate)
        {
            var user = new ApplicationUser()
            {
                UserName = registered.UserName,
                Email = registered.Email,
                PositionId = registered.PositionId,
                DepartmentId= registered.DepartmentId,
                PhoneNumber = registered.PhoneNumber
                
            };

            var result = await _manager.CreateAsync(user, registered.Password);

            if (result.Succeeded)
            {
                await _manager.AddToRoleAsync(user, registered.Roles);
                return new UserDTO { Id = user.Id, UserName = registered.UserName, Role = await _manager.GetRolesAsync(user) };
            }
            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(registered.Password) :
                      error.Code.Contains("Email") ? nameof(registered.Email) :
                        error.Code.Contains("UserName") ? nameof(registered.UserName) : "";
                modelstate.AddModelError(errorKey, error.Description);

            };
            return null;

        }
        public async Task<UserDTO> Authenticate(string UserName, string Password)
        {
            var user = await _manager.FindByNameAsync(UserName);
            bool validPassword = await _manager.CheckPasswordAsync(user, Password);
            var result = await _signInManager.PasswordSignInAsync(UserName, Password, true, false);

            if (validPassword & result.Succeeded)
            {
                return new UserDTO
                {
                    Id = user.Id,
                    UserName = UserName,
                    PositionId
                    = user.PositionId,
                    DepartmentId = user.DepartmentId,
               
                    Role = await _manager.GetRolesAsync(user)
                };

            }
            return null;
        }
     
        public async Task<UserDTO> GetUser(ClaimsPrincipal principal)
        {
            var user = await _manager.GetUserAsync(principal);
            return new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                PositionId
                = user.PositionId,
                DepartmentId= user.DepartmentId

            };
        }
        public async Task<List<UserListDTO>> GetAllUsers()
        {
           
            var Users = await _manager.Users.ToListAsync();
           
            var users = new List<UserListDTO>();
            foreach (var user in Users)
            {
                UserListDTO userDTO = new UserListDTO
                {
                    Id= user.Id,
                    UserName = user.UserName,
                    Email=user.Email,
                    PhoneNumber= user.PhoneNumber,
                    PositionId
                = user.PositionId,
                    DepartmentId = user.DepartmentId,
                    DepartmentName =  _context.Departments.FirstOrDefault(d => d.Id == user.DepartmentId)?.Name,
             PositionName=  _context.Positions.FirstOrDefault(d => d.Id == user.PositionId)?.Position,

                    Role = await _manager.GetRolesAsync(user)


                };
                users.Add(userDTO);

            }

            return users;
        }
        public async Task<bool> DeleteUser(string userId)
        {
            var user = await _manager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _manager.DeleteAsync(user);
                return result.Succeeded;
            }
            return false;
        }


    }
}
       
