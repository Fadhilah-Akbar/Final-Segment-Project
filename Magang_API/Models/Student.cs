using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Magang_API.Models;

public partial class Student
{
    public string Nim { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public bool? IsApproval { get; set; }

    public string? MentorId { get; set; }

    public int? Score { get; set; }

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    [JsonIgnore]
    public virtual Account? Account { get; set; }

    [JsonIgnore]
    public virtual Employee? Mentor { get; set; }

    [JsonIgnore]
    public virtual Profiling? Profiling { get; set; }

    [JsonIgnore]
    public virtual Status? Status { get; set; }
}
