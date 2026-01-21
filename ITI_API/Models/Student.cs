using System;
using System.Collections.Generic;

namespace ITI_API.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public int? DepartmentId { get; set; }

    public string? Email { get; set; }

    public virtual Department? Department { get; set; }
}
