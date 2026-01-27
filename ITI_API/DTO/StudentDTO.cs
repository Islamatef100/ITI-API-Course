using ITI_API.Models;

namespace ITI_API.DTO
{
    public class StudentDTO
    {
        public int StudentId { get; set; }

        public string FullName { get; set; }
        public DateOnly? BirthDate { get; set; }

        public string DepartmentName { get; set; }
        public string? Email { get; set; }
    }
}
