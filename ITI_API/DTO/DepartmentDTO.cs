namespace ITI_API.DTO
{
    public class DepartmentDTO
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }
        public List<string>? StudentNames { get; set; } 
    }
}
