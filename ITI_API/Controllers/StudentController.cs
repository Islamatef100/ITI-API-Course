using ITI_API.DTO;
using ITI_API.Interfaces;
using ITI_API.Models;
using ITI_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_API.Controllers
{
    [Controller]
    [Route("Api/[Controller]")]
    public class StudentController(IStudentRepository repo) : ControllerBase
    {
        [HttpGet("get-all-students")]
        public async Task<IActionResult> GetAllStudents()
        {
          var result = await repo.GetAllStudentsAsync();
            return result is null ? NoContent() : Ok(result);
        }
        [HttpGet("get-student/{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var result = await repo.GetStudentByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }
        [HttpPost("add-student")]
        public async Task<IActionResult> AddStudent([FromBody]Student s)
        {
            if (s is null) return BadRequest();

            var result = await repo.AddStudentAsync(s);
            return result is null ?  StatusCode(500, "Something went wrong while saving to the database.") : Created();
        }
        [HttpPut("update-student")]
        public async Task<IActionResult> UpdateStudent([FromBody] Student s)
        {
            if (s is null) return BadRequest();
            await repo.UpdateStudentAsync(s);
            return NoContent();
        }
        [HttpDelete("delete-student")]
        public async Task<IActionResult> DeleteStudent([FromBody] Student s)
        {
            if (s is null) return BadRequest();

            await repo.DeleteStudentAsync(s);
            return NoContent();
        }
    }
}
