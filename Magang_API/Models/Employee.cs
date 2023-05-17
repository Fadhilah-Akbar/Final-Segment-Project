using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Magang_API.Models;

public partial class Employee
{
    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public DateTime HiringDate { get; set; }

    public int Gender { get; set; }

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public int? DepartmentId { get; set; }

    public int? StudentId { get; set; }

    [JsonIgnore]
    public virtual Account? Account { get; set; }

    [JsonIgnore]
    public virtual Department? Department { get; set; }

    [JsonIgnore]
    public virtual Profiling? Profiling { get; set; }

    [JsonIgnore]
    public virtual Student? Student { get; set; }

    [JsonIgnore]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}

public enum Gender
{
    Male,Female
}