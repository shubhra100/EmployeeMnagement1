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

        // APPLY LEAVE
        [HttpPost("apply")]
        public async Task<IActionResult> ApplyLeave(LeaveRequest leave)
        {
            leave.Status = "Pending";
            leave.AppliedOn = DateTime.Now;

            _context.LeaveRequests.Add(leave);
            await _context.SaveChangesAsync();

            return Ok(leave);
        }

        // GET ALL LEAVE REQUESTS
        [HttpGet]
        public async Task<IActionResult> GetAllLeaves()
        {
            var leaves = await _context.LeaveRequests
                .Include(l => l.Employee)
                .ToListAsync();

            return Ok(leaves);
        }

        // APPROVE LEAVE
        [HttpPut("approve/{id}")]
        public async Task<IActionResult> ApproveLeave(int id)
        {
            var leave = await _context.LeaveRequests.FindAsync(id);

            if (leave == null)
                return NotFound();

            leave.Status = "Approved";
            await _context.SaveChangesAsync();

            return Ok(leave);
        }

        // REJECT LEAVE
        [HttpPut("reject/{id}")]
        public async Task<IActionResult> RejectLeave(int id)
        {
            var leave = await _context.LeaveRequests.FindAsync(id);

            if (leave == null)
                return NotFound();

            leave.Status = "Rejected";
            await _context.SaveChangesAsync();

            return Ok(leave);
        }
    }
}