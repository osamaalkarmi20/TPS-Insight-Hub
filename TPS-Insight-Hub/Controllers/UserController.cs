
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TPS_Insight_Hub.Models;
using TPS_Insight_Hub.Models.DTO;
using TPS_Insight_Hub.Models.Interface;


namespace TPS_Insight_Hub.Controllers
{
    public class UserController : Controller
    {

        // Use DI to bring in the user service
        private readonly IUser userService;
        private readonly HubDbContext _context;
       private readonly SignInManager<ApplicationUser> _signInManager;


        public UserController(IUser service, HubDbContext context, SignInManager<ApplicationUser> signInManager)
        {
            userService = service;
            _context = context;
            _signInManager = signInManager;
        }

        public IActionResult Authenticate()
        {
            return View();
        }



        [Authorize(Roles = "admin")]
        [HttpGet]

        public IActionResult SignUp()
        {
            var model = new RegisterUserDTO
            {
                Positions = _context.Positions.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Position }).ToList(),
                Departments = _context.Departments.Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name }).ToList()
            };

            return View(model);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]

        public async Task<ActionResult<UserDTO>> SignUp(RegisterUserDTO registerDTO)
        {

            var user = await userService.Register(registerDTO, this.ModelState);

            if (ModelState.IsValid)
            {
                return Redirect("Authenticate");
            }
            var model = new RegisterUserDTO
            {
                Positions = _context.Positions.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Position }).ToList(),
                Departments = _context.Departments.Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name }).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Authenticate(LoginDTO data)
        {
            if (data.UserName != null && data.Password != null)
            {
                var user = await userService.Authenticate(data.UserName, data.Password);

                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index", "Home");

                }

                return View(user);
            }
            return View();
        }

        public async Task<ActionResult<List<UserListDTO>>> GetAllUsers()
        {
            var users = await userService.GetAllUsers();
            return View(users);
        }


        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            return RedirectToAction("Authenticate");
        }

        [Authorize(Roles = "admin")]
       
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await userService.DeleteUser(id);

            if (result)
            {
                return RedirectToAction("GetAllUsers");
            }

            // Handle failure to delete user appropriately
            ModelState.AddModelError("", "Failed to delete the user.");
            var users = await userService.GetAllUsers();
            return View("GetAllUsers", users);
        }
    }
}