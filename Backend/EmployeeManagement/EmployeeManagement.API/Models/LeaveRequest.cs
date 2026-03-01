using System;
using System.Text.Json.Serialization;

namespace EmployeeManagement.API.Models
{
    public partial class LeaveRequest
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Reason { get; set; }

        public string? Status { get; set; }

        public DateTime AppliedOn { get; set; }

        // 🔥 IMPORTANT FIX
        [JsonIgnore]
        public virtual Employee? Employee { get; set; }
    }
}