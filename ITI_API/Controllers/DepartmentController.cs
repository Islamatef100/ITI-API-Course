using ITI_API.DTO;
using ITI_API.Interfaces;
using ITI_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_API.Controllers
{
    [Controller]
    public class DepartmentController(IDepartmentRepository repo) : ControllerBase
    {
        [HttpGet("get-all-departments")]
        public async Task<IActionResult> GetAllDepartments()
        {
            var result = await repo.GetAllDepartmentsAsync();
            return result is null ? NoContent() : Ok(result);
        }
        [HttpGet("get-department/{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var result = await repo.GetDepartmentByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }
        [HttpPost("add-department")]
        public async Task<IActionResult> AddDepartment([FromBody] Department s)
        {
            if (s is null) return BadRequest();

            var result = await repo.AddDepartmentAsync(s);
            return result is null ? StatusCode(500, "Something went wrong while saving to the database.") : Created();
        }
        [HttpPut("update-department")]
        public async Task<IActionResult> UpdateDepartment([FromBody] Department s)
        {
            if (s is null) return BadRequest();

            await repo.UpdateDepartmentAsync(s);
            return NoContent();
        }
        [HttpDelete("delete-department")]
        public async Task<IActionResult> DeleteDepartment([FromBody] Department s)
        {
            if (s is null) return BadRequest();

            await repo.DeleteDepartmentAsync(s);
            return NoContent();
        }
    }
}
