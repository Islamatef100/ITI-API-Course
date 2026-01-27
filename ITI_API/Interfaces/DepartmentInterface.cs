using ITI_API.DTO;
using ITI_API.Models;

namespace ITI_API.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<List<DepartmentDTO>> GetAllDepartmentsAsync();
        Task<Department?> GetDepartmentByIdAsync(int id);
        Task<Department> AddDepartmentAsync(Department department);
        Task UpdateDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(Department department);
    }
}
