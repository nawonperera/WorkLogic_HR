using System;
using System.Collections.Generic;
using System.Text;
using WorkLogic_HR.Core.Domain.Entities;
using WorkLogic_HR.Core.Domain.RepositoryContracts;
using WorkLogic_HR.Core.DTO;
using WorkLogic_HR.Core.Helpers;
using WorkLogic_HR.Core.ServiceContracts;

namespace WorkLogic_HR.Core.Services;

public class PublicHolidayService : IPublicHolidayServiec
{
    private readonly IPublicHolidayRepository _holidayRepository;
    private readonly CacheHelper _cacheHelper;
    public PublicHolidayService(IPublicHolidayRepository holidayRepository, CacheHelper cacheHelper)
    {
        _holidayRepository = holidayRepository;
        _cacheHelper = cacheHelper;
    }
    public bool CreateHoliday(PublicHolidayDto holiday)
    {
        try
        {
            if (holiday == null)
            {
                throw new ArgumentNullException(nameof(holiday));
            }
            _cacheHelper.RemoveCache("all_public_holidays");

            PublicHolidays holidayEntity = MapToEntity(holiday);

            _holidayRepository.Create(holidayEntity);

            return _holidayRepository.Save();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{nameof(CreateHoliday)}: {ex.Message}");
            return false;
        }
    }

    public bool DeleteHoliday(int id)
    {
        try
        {
            if (id <= 0)
            {
                return false;
            }
            _cacheHelper.RemoveCache("all_public_holidays");
            PublicHolidays? holiday = _holidayRepository.GetById(id);
            if (holiday == null)
            {
                return false;
            }
            _holidayRepository.Delete(id);
            return _holidayRepository.Save();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{nameof(DeleteHoliday)}: {ex.Message}");
            return false;
        }
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
        return _cacheHelper.CacheLong("all_public_holidays", () =>
        {
            return _holidayRepository.GetAll().Select(e => MapToDto(e)).ToList();
        });
    }

    public bool UpdateHoliday(PublicHolidayDto holiday)
    {
        try
        {
            if (holiday == null)
            {
                throw new ArgumentNullException(nameof(holiday));
            }
            _cacheHelper.RemoveCache("all_public_holidays");
            PublicHolidays holidayEntity = MapToEntity(holiday);

            _holidayRepository.Update(holidayEntity);
            return _holidayRepository.Save();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{nameof(UpdateHoliday)}: {ex.Message}");
            return false;
        }
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
