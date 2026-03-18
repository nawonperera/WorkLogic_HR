using System;
using System.Collections.Generic;
using System.Text;
using WorkLogic_HR.Core.Domain.Entities;
using WorkLogic_HR.Core.Domain.RepositoryContracts;
using WorkLogic_HR.Core.DTO;
using WorkLogic_HR.Core.ServiceContracts;

namespace WorkLogic_HR.Core.Services;

public class PublicHolidayService : IPublicHolidayServiec
{
    private readonly IPublicHolidayRepository _holidayRepository;

    public PublicHolidayService(IPublicHolidayRepository holidayRepository)
    {
        _holidayRepository = holidayRepository;
    }
    public bool CreateHoliday(PublicHolidayDto holiday)
    {
        if (holiday == null)
        {
            throw new ArgumentNullException(nameof(holiday));
        }

        PublicHolidays holidayEntity = MapToEntity(holiday);

        _holidayRepository.Create(holidayEntity);

        return _holidayRepository.Save();
    }

    public bool DeleteHoliday(int id)
    {
        if (id <= 0)
        {
            return false;
        }
        PublicHolidays? holiday = _holidayRepository.GetById(id);
        if (holiday == null)
        {
            return false;
        }
        _holidayRepository.Delete(id);
        return _holidayRepository.Save();
    }

    public PublicHolidayDto? GetHolidayById(int id)
    {
        if (id <= 0)
        {
            return null;
        }
        PublicHolidays? holiday = _holidayRepository.GetById(id);

        if (holiday == null)
            return null;

        return MapToDto(holiday);
    }

    public List<PublicHolidayDto> GetSelectedHolidays(DateTime start, DateTime end)
    {
        return _holidayRepository.GetSelectedHolidays(start, end)
                .Select(MapToDto)
                .ToList();
    }

    public List<PublicHolidayDto> PublicHolidays()
    {
        return _holidayRepository.GetAll().Select(e => MapToDto(e)).ToList();
    }

    public bool UpdateHoliday(PublicHolidayDto holiday)
    {
        if (holiday == null)
        {
            throw new ArgumentNullException(nameof(holiday));
        }

        PublicHolidays holidayEntity = MapToEntity(holiday);

        _holidayRepository.Update(holidayEntity);
        return _holidayRepository.Save();
    }

    //Helper methods to Employee to EmployeeDto Viseversa (We can use automapper for this. since there is few properties here I am using this)

    private PublicHolidayDto MapToDto(PublicHolidays holiday) => new PublicHolidayDto
    {
        Id = holiday.Id,
        Date = holiday.Date,
        Name = holiday.Name
    };

    private PublicHolidays MapToEntity(PublicHolidayDto holidaySto) => new PublicHolidays
    {
        Id = holidaySto.Id,
        Date = holidaySto.Date,
        Name = holidaySto.Name
    };
}
