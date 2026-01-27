using ITI_API.DTO;
using ITI_API.Models;

namespace ITI_API.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<StudentDTO>> GetAllStudentsAsync();
        Task<Student?> GetStudentByIdAsync(int id);
        Task<Student> AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(Student student);
    }
}
