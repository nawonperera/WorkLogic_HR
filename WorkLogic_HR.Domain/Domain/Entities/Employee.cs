using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WorkLogic_HR.Core.Domain.Entities;

public class Employee
{
    [Key]
    public Guid Id { get; set; }
    [StringLength(40)]
    public string? Name { get; set; }
    [StringLength(40)]
    public string? Email { get; set; }
    [StringLength(40)]
    public string? Role { get; set; }
}
