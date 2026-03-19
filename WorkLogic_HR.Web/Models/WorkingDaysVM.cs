using System.ComponentModel.DataAnnotations;
using WorkLogic_HR.Core.DTO;

namespace WorkLogic_HR.Web.Models;

public class WorkingDaysVM
{
    [Required(ErrorMessage = "Start date is required")]
    [DataType(DataType.Date)]
    [Display(Name = "Start Date")]
    public DateTime? StartDate { get; set; }
    [Required(ErrorMessage = "End date is required")]
    [DataType(DataType.Date)]
    [Display(Name = "End Date")]
    public DateTime? EndDate { get; set; }

    public int? WorkingDays { get; set; }

    public List<PublicHolidayDto> PublicHolidaysBetweenDates = new List<PublicHolidayDto>();
}
