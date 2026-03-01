using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.API.Models;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly EmployeeManagementContext _context;

        public AttendanceController(EmployeeManagementContext context)
        {
            _context = context;
        }

        // MARK ATTENDANCE
        [HttpPost("mark")]
        public async Task<IActionResult> MarkAttendance(Attendance attendance)
        {
            // Check duplicate attendance for same employee & date
            bool alreadyMarked = await _context.Attendances
                .AnyAsync(a => a.EmployeeId == attendance.EmployeeId
                               && a.AttendanceDate == attendance.AttendanceDate);

            if (alreadyMarked)
                return BadRequest("Attendance already marked for this date.");

            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();

            return Ok(attendance);
        }

        // GET ALL ATTENDANCE
        [HttpGet]
        public async Task<IActionResult> GetAllAttendance()
        {
            var attendanceList = await _context.Attendances
                .Include(a => a.Employee)
                .ToListAsync();

            return Ok(attendanceList);
        }

        // GET ATTENDANCE BY EMPLOYEE
        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> GetByEmployee(int employeeId)
        {
            var attendance = await _context.Attendances
                .Where(a => a.EmployeeId == employeeId)
                .ToListAsync();

            return Ok(attendance);
        }
    }
}