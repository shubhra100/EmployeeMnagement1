using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.API.Models;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly EmployeeManagementContext _context;

        public DashboardController(EmployeeManagementContext context)
        {
            _context = context;
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary()
        {
            var today = DateTime.Today;

            var totalEmployees = await _context.Employees.CountAsync();

            var totalPresent = await _context.Attendances
                .CountAsync(a => a.AttendanceDate == today && a.IsPresent);

            var totalAbsent = totalEmployees - totalPresent;

            var pendingLeaves = await _context.LeaveRequests
                .CountAsync(l => l.Status == "Pending");

            return Ok(new
            {
                totalEmployees,
                totalPresent,
                totalAbsent,
                pendingLeaves
            });
        }
    }
}