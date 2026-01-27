using ITI_API.DTO;
using ITI_API.Interfaces;
using ITI_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ITI_API.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ItiContext _context;

        public DepartmentRepository(ItiContext context)
        {
            _context = context;
        }

        public async Task<List<DepartmentDTO>> GetAllDepartmentsAsync()
        {
            return await _context.Departments
                .Select(x => new DepartmentDTO
                {
                    DepartmentId = x.DepartmentId,
                    DepartmentName = x.DepartmentName,
                    StudentNames = x.Students!.Select(s => s.FirstName + " " + s.LastName).ToList()
                }).ToListAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(x => x.DepartmentId == id);
        }

        public async Task<Department> AddDepartmentAsync(Department department)
        {
            // var result = await _context.Departments.AddAsync(department);
            _context.Entry(department).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            _context.Entry(department).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(Department department)
        {
            _context.Entry(department).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
