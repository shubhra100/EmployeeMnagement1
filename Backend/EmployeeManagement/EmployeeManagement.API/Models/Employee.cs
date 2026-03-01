using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EmployeeManagement.API.Models
{
    public partial class Employee
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Department { get; set; } = null!;

        public decimal Salary { get; set; }

        public int UserId { get; set; }

        // 🔥 IMPORTANT FIXES BELOW

        [JsonIgnore]
        public virtual User? User { get; set; }

        [JsonIgnore]
        public virtual ICollection<Attendance>? Attendances { get; set; }

        [JsonIgnore]
        public virtual ICollection<LeaveRequest>? LeaveRequests { get; set; }
    }
}