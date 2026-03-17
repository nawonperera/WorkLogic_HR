using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WorkLogic_HR.Core.DTO;

public class EmployeeDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    [Display(Name = "Full Name")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [StringLength(150, ErrorMessage = "Email cannot exceed 150 characters")]
    [Display(Name = "Email Address")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Job Position is required")]
    [StringLength(100, ErrorMessage = "Job Position cannot exceed 100 characters")]
    [Display(Name = "Job Position")]
    public string? JobPosition { get; set; }
}
