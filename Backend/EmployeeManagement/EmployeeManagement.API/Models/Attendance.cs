using System;
using System.Text.Json.Serialization;

namespace EmployeeManagement.API.Models
{
    public partial class Attendance
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public DateTime AttendanceDate { get; set; }

        public bool IsPresent { get; set; }

        // 🔥 IMPORTANT FIX
        [JsonIgnore]
        public virtual Employee? Employee { get; set; }
    }
}