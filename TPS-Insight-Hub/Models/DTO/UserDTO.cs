using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPS_Insight_Hub
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public int PositionId { get; set; }
        public int DepartmentId { get; set; }
        public IList<string> Role { get; set; }
    }
}
