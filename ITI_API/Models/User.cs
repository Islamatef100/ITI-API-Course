namespace ITI_API.Models
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }

        // Navigation
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }

}
