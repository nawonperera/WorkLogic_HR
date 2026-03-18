using System;
using System.Collections.Generic;
using System.Text;
using WorkLogic_HR.Core.DTO;

namespace WorkLogic_HR.Core.ServiceContracts;

public interface IWorkingDaysService
{
    public int WorkingDays(DateTime startDate, DateTime endDate);
    public List<PublicHolidayDto> GetHolidaysBetweenDates(DateTime startDate, DateTime endDate);
}
