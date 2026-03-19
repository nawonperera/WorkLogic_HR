using Microsoft.AspNetCore.Mvc;
using WorkLogic_HR.Core.ServiceContracts;
using WorkLogic_HR.Web.Models;

namespace WorkLogic_HR.Web.Controllers;

public class WorkingDaysController : Controller
{
    private readonly IWorkingDaysService _workingDaysService;

    public WorkingDaysController(IWorkingDaysService workingDaysService)
    {
        _workingDaysService = workingDaysService;
    }
    public IActionResult Index()
    {
        WorkingDaysVM model = new WorkingDaysVM()
        {
            StartDate = DateTime.Today,
            EndDate = DateTime.Today.AddDays(7),
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Calculate(WorkingDaysVM model)
    {
        if (!model.StartDate.HasValue || !model.EndDate.HasValue)
        {
            return View("Index", model);
        }

        int workingDays = _workingDaysService.WorkingDays(model.StartDate.Value,model.EndDate.Value);

        if(workingDays == -1)
        {
            model.WorkingDays = null;
        }
        else
        {
            model.WorkingDays = workingDays;
            model.PublicHolidaysBetweenDates = _workingDaysService.GetHolidaysBetweenDates(model.StartDate.Value, model.EndDate.Value);
        }

        return View("Index", model);
    }
}
