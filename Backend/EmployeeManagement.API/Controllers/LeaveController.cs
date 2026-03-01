using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.API.Models;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly EmployeeManagementContext _context;

        public LeaveController(EmployeeManagementContext context)
        {
            _context = context;
        }

        /////////////////////////////////////////////////////////
        // APPLY LEAVE
        /////////////////////////////////////////////////////////

        [HttpPost("apply")]
        public async Task<IActionResult> ApplyLeave([FromBody] LeaveRequest leaveRequest)
        {
            // Check if employee exists
            var employeeExists = await _context.Employees
                .AnyAsync(e => e.Id == leaveRequest.EmployeeId);

            if (!employeeExists)
                return BadRequest("Employee does not exist.");

            // Validate dates
            if (leaveRequest.EndDate < leaveRequest.StartDate)
                return BadRequest("End date cannot be before start date.");

            leaveRequest.Status = "Pending";
            leaveRequest.AppliedOn = DateTime.Now;

            _context.LeaveRequests.Add(leaveRequest);
            await _context.SaveChangesAsync();

            return Ok(leaveRequest);
        }

        /////////////////////////////////////////////////////////
        // GET ALL LEAVES
        /////////////////////////////////////////////////////////

        [HttpGet]
        public async Task<IActionResult> GetAllLeaves()
        {
            var leaves = await _context.LeaveRequests
                .Include(l => l.Employee)
                .ToListAsync();

            return Ok(leaves);
        }

        /////////////////////////////////////////////////////////
        // GET LEAVES BY EMPLOYEE
        /////////////////////////////////////////////////////////

        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> GetLeavesByEmployee(int employeeId)
        {
            var leaves = await _context.LeaveRequests
                .Where(l => l.EmployeeId == employeeId)
                .ToListAsync();

            return Ok(leaves);
        }

        /////////////////////////////////////////////////////////
        // APPROVE LEAVE
        /////////////////////////////////////////////////////////

        [HttpPut("{id}/approve")]
        public async Task<IActionResult> ApproveLeave(int id)
        {
            var leave = await _context.LeaveRequests.FindAsync(id);

            if (leave == null)
                return NotFound("Leave request not found.");

            leave.Status = "Approved";

            await _context.SaveChangesAsync();

            return Ok(leave);
        }

        /////////////////////////////////////////////////////////
        // REJECT LEAVE
        /////////////////////////////////////////////////////////

        [HttpPut("{id}/reject")]
        public async Task<IActionResult> RejectLeave(int id)
        {
            var leave = await _context.LeaveRequests.FindAsync(id);

            if (leave == null)
                return NotFound("Leave request not found.");

            leave.Status = "Rejected";

            await _context.SaveChangesAsync();

            return Ok(leave);
        }
    }
}