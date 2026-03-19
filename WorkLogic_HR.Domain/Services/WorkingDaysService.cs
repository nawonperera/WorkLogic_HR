using System;
using System.Collections.Generic;
using System.Text;
using WorkLogic_HR.Core.DTO;
using WorkLogic_HR.Core.ServiceContracts;

namespace WorkLogic_HR.Core.Services;

public class WorkingDaysService : IWorkingDaysService
{
    private readonly IPublicHolidayServiec _publicHolidayService;

    public WorkingDaysService(IPublicHolidayServiec publicHolidayService)
    {
        _publicHolidayService = publicHolidayService;
    }
    public List<PublicHolidayDto> GetHolidaysBetweenDates(DateTime startDate, DateTime endDate)
    {
        return _publicHolidayService.GetSelectedHolidays(startDate, endDate).ToList();
    }

    public int WorkingDays(DateTime startDate, DateTime endDate)
    {
        if (startDate.Date > endDate.Date)
        {
            return -1;
        }

        if (startDate.DayOfWeek == DayOfWeek.Saturday || startDate.DayOfWeek == DayOfWeek.Sunday)
        {
            return -1;
        }

        int workingDays = 0;
        DateTime currentDate = startDate.Date;
        List<PublicHolidayDto> publicHolidays = _publicHolidayService.PublicHolidays();

        while (currentDate <= endDate.Date)
        {
            if (!publicHolidays.Any(x => x.Date.Date == currentDate) && currentDate.DayOfWeek != DayOfWeek.Sunday && currentDate.DayOfWeek != DayOfWeek.Saturday)
            {
                workingDays++;
            }
            currentDate = currentDate.AddDays(1);
        }
        return workingDays;
    }
}
