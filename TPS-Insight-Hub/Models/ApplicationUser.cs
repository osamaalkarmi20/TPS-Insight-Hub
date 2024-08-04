using Microsoft.AspNetCore.Identity;

namespace TPS_Insight_Hub.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int PositionId { get; set; }
        public int DepartmentId { get; set; }
        public LookUpDepartment? LookUpDepartment { get; set; }
        public LookUpPosition? DepartmentPosition { get; set; }
    }
}
