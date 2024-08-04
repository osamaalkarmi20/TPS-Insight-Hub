namespace TPS_Insight_Hub.Models.DTO
{
    public class UserListDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public int PositionId { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }
        public string Email { get; set; }
        public IList<string> Role { get; set; }
        public string PhoneNumber { get; set; }
    }
}
