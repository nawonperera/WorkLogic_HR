using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WorkLogic_HR.Core.DTO;

public class PublicHolidayDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Date is required")]
    [DataType(DataType.Date)]
    [Display(Name = "Holiday Date")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Holiday name is required")]
    [StringLength(200, ErrorMessage = "Name cannot exceed 200 characters")]
    [Display(Name = "Holiday Name")]
    public string? Name { get; set; } 
}
