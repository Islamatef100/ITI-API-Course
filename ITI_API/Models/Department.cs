using System;
using System.Collections.Generic;

namespace ITI_API.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
