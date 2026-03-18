using Microsoft.AspNetCore.Mvc;
using WorkLogic_HR.Core.DTO;
using WorkLogic_HR.Core.ServiceContracts;
using WorkLogic_HR.Core.Services;

namespace WorkLogic_HR.Web.Controllers;

public class PublicHolidayController : Controller
{
    private readonly IPublicHolidayServiec _holidayService;

    public PublicHolidayController(IPublicHolidayServiec holidayService)
    {
        _holidayService = holidayService;
    }

    public IActionResult Index()
    {
        var holidays = _holidayService.PublicHolidays();
        return View(holidays);
    }

    #region CreatePublicHoliday
    public IActionResult Create()
    {
        PublicHolidayDto publicHoliday = new() { Date = DateTime.Today };
        return View(publicHoliday);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(PublicHolidayDto holidayDto)
    {
        if (ModelState.IsValid)
        {
            if (_holidayService.CreateHoliday(holidayDto))
            {
                TempData["SuccessMessage"] = "Public holiday added successfully.";
                return RedirectToAction(nameof(Index));
            }
        }
        return View(holidayDto);
    }

    #endregion

    #region DeletePublicHoliday

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        if (_holidayService.DeleteHoliday(id))
        {
            TempData["SuccessMessage"] = "Public holiday deleted.";
        }
        else
        {
            TempData["ErrorMessage"] = "Failed to delete holiday.";
        }
        return RedirectToAction(nameof(Index));
    }
    #endregion
}
