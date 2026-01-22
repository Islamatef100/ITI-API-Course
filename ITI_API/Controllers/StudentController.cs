using ITI_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_API.Controllers
{
    [Controller]
    [Route("Api/[Controller]")]
    public class StudentController(ItiContext _context) : ControllerBase
    {
        [HttpGet("get-all-students")]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await _context.Students.ToListAsync();
            return result is null ? NoContent() : Ok(result);
        }
        [HttpGet("get-student/{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var result = await _context.Students.FirstOrDefaultAsync(x=>x.StudentId == id);
            return result is null ? NotFound() : Ok(result);
        }
        [HttpPost("add-student")]
        public async Task<IActionResult> AddStudent([FromBody]Student s)
        {
            if (s is null) return BadRequest();

            var result = await _context.Students.AddAsync(s);
           await _context.SaveChangesAsync();
            return result is null ?  StatusCode(500, "Something went wrong while saving to the database.") : Created();
        }
        [HttpPut("update-student")]
        public async Task<IActionResult> UpdateStudent([FromBody] Student s)
        {
            if (s is null) return BadRequest();

             _context.Entry(s).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("delete-student")]
        public async Task<IActionResult> DeleteStudent([FromBody] Student s
        {
            if (s is null) return BadRequest();

            _context.Entry(s).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
