using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WorkLogic_HR.Infrastucture;
//This is only for testing the repositories
public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Database generates new Id automatically
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

[Table("PublicHolidays")] //this class is mapped to publicHolidays table
public class PublicHolidays
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required(ErrorMessage = "Date is required")]
    [DataType(DataType.Date)]
    [Display(Name = "Holiday Date")]
    public DateTime Date { get; set; }
    [Required(ErrorMessage = "Holiday name is required")]
    [StringLength(200, ErrorMessage = "Cannot go beyong 200 characters")]
    [Display(Name = "Holiday Name")]
    public string? Name { get; set; }
}
