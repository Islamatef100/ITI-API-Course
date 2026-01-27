using ITI_API.DTO;
using ITI_API.Interfaces;
using ITI_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ITI_API.Repositories
{
    public class StudentRepository : IStudentRepository
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

        public async Task<Student> AddStudentAsync(Student student)
        {
            //   var result = await _context.Students.AddAsync(student);
            _context.Entry(student).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task UpdateStudentAsync(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(Student student)
        {
            _context.Entry(student).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
