using System;
using System.Collections.Generic;
using System.Text;
using WorkLogic_HR.Core.DTO;
using WorkLogic_HR.Core.Helpers;
using WorkLogic_HR.Core.ServiceContracts;

namespace WorkLogic_HR.Core.Services;

public class WorkingDaysService : IWorkingDaysService
{
    private readonly IPublicHolidayServiec _publicHolidayService;
    private readonly CacheHelper _cacheHelper;

    public WorkingDaysService(IPublicHolidayServiec publicHolidayService, CacheHelper cacheHelper)
    {
        _publicHolidayService = publicHolidayService;
        _cacheHelper = cacheHelper;
    }
    public List<PublicHolidayDto> GetHolidaysBetweenDates(DateTime startDate, DateTime endDate)
    {
        return _publicHolidayService.GetSelectedHolidays(startDate, endDate).ToList();
    }

    public int WorkingDays(DateTime startDate, DateTime endDate)
    {
        try
        {
            if (startDate.Date > endDate.Date)
            {
                return -1;
            }

            if (startDate.DayOfWeek == DayOfWeek.Saturday || startDate.DayOfWeek == DayOfWeek.Sunday)
            {
                return -1;
            }

            string cacheKey = $"holidays_dates_{startDate:yyyyMMdd}_{endDate:yyyyMMdd}";
            List<DateTime> holidayDates = _cacheHelper.Cached(cacheKey, () =>
            {
                return _publicHolidayService
                    .GetSelectedHolidays(startDate, endDate)
                    .Select(h => h.Date.Date)
                    .ToList();
            });

            int workingDays = 0;
            DateTime currentDate = startDate.Date;
            //List<PublicHolidayDto> publicHolidays = _publicHolidayService.PublicHolidays();

            while (currentDate <= endDate.Date)
            {
                if (!holidayDates.Any(x => x.Date == currentDate) && currentDate.DayOfWeek != DayOfWeek.Sunday && currentDate.DayOfWeek != DayOfWeek.Saturday)
                {
                    workingDays++;
                }
                currentDate = currentDate.AddDays(1);
            }
            return workingDays;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{nameof(WorkingDays)}: {ex.Message}");
            return -1;
        }
    }
}
