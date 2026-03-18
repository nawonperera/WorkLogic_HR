using System;
using System.Collections.Generic;
using System.Text;
using WorkLogic_HR.Core.DTO;

namespace WorkLogic_HR.Core.ServiceContracts;

public interface IPublicHolidayServiec
{
    public List<PublicHolidayDto> PublicHolidays();
    public PublicHolidayDto? GetHolidayById(int id);
    public bool CreateHoliday(PublicHolidayDto holiday);
    public bool UpdateHoliday(PublicHolidayDto holiday);
    public bool DeleteHoliday(int id);
    List<PublicHolidayDto> GetSelectedHolidays(DateTime start, DateTime end);
}
