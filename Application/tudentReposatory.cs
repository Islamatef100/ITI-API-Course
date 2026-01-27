namespace Application
{
    using global::ITI_API.DTO;
    using global::ITI_API.Models;
    using Microsoft.EntityFrameworkCore;

    namespace Application.Repositories
    {
        public class StudentRepository
        {
            private readonly ItiContext _context;

            public StudentRepository(ItiContext context)
            {
                _context = context;
            }

            public async Task<List<StudentDTO>> GetAllStudentsAsync()
            {
                return await _context.Students
                    .Select(x => new StudentDTO
                    {
                        StudentId = x.StudentId,
                        FullName = x.FirstName + " " + x.LastName,
                        BirthDate = x.BirthDate,
                        DepartmentName = x.Department.DepartmentName,
                        Email = x.Email
                    }).ToListAsync();
            }

            public async Task<Student?> GetStudentByIdAsync(int id)
            {
                return await _context.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            }

            public async Task<bool> AddStudentAsync(Student student)
            {
                await _context.Students.AddAsync(student);
                return await _context.SaveChangesAsync() > 0;
            }

            public async Task<bool> UpdateStudentAsync(Student student)
            {
                _context.Entry(student).State = EntityState.Modified;
                return await _context.SaveChangesAsync() > 0;
            }

            public async Task<bool> DeleteStudentAsync(Student student)
            {
                _context.Entry(student).State = EntityState.Deleted;
                return await _context.SaveChangesAsync() > 0;
            }
        }
    }

}
