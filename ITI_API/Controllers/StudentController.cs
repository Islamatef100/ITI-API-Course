using ITI_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_API.Controllers
{
    [Controller]
    [Route("Api/[Controller]")]
    public class StudentController(ItiContext _context) :ControllerBase
    {
        [HttpGet("get-all-students")]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await _context.Students.ToListAsync();
            return Ok(result);
        }
    }
}
