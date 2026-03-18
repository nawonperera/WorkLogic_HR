using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WorkLogic_HR.Core.Domain.Entities;

[Table("PublicHolidays")] //this class is mapped to publicHolidays table
public class PublicHolidays
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required(ErrorMessage ="Date is required")]
    [DataType(DataType.Date)]
    [Display(Name ="Holiday Date")]
    public DateTime Date { get; set; }
    [Required(ErrorMessage ="Holiday name is required")]
    [StringLength(200, ErrorMessage="Cannot go beyong 200 characters")]
    [Display(Name="Holiday Name")]
    public string? Name { get; set; }
}
