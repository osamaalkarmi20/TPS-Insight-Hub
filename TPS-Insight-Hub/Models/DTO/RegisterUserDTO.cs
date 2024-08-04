using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPS_Insight_Hub
{
    public class RegisterUserDTO
    {


        public string UserName { get; set; }
        public int PositionId { get; set; }
        public int DepartmentId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Roles { get; set; }
        public IEnumerable<SelectListItem>? Positions { get; set; } 
        public IEnumerable<SelectListItem>? Departments { get; set; }
    }
}
