using System;
using System.Collections.Generic;

namespace Magang_API.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? MentorId { get; set; }

    public int? Score { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Employee? Mentor { get; set; }
}
