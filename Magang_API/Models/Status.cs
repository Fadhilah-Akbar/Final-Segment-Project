﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Magang_API.Models;

public partial class Status
{
    public string StudentId { get; set; } = null!;

    public int? DepartmentId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool? Status1 { get; set; }

    [JsonIgnore]
    public virtual Department? Department { get; set; }

    [JsonIgnore]
    public virtual Student Student { get; set; } = null!;
}
