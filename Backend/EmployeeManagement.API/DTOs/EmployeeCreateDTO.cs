namespace EmployeeManagement.API.DTOs
{
    public class EmployeeCreateDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public int UserId { get; set; }
    }
}