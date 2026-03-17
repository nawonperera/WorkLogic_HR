using Microsoft.AspNetCore.Mvc;
using WorkLogic_HR.Core.DTO;
using WorkLogic_HR.Core.ServiceContracts;

namespace WorkLogic_HR.Web.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    public IActionResult Index()
    {
        List<EmployeeDto> employees = _employeeService.GetAllEmployees();
        return View(employees);
    }

    

    public IActionResult IndividualDetails(int? id)
    {
        if(id == null)
        {
            return NotFound();
        }
        EmployeeDto? employee = _employeeService.GetEmployeeById(id.Value);
        if (employee==null)
        {
            return NotFound();
        }
        return View(employee);
    }

    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create (EmployeeDto employeeDto)
    {
        if (ModelState.IsValid)
        {
            if(_employeeService.CreateEmployee(employeeDto))
            {
                TempData["SuccessMessage"] = "Employee created successfully";
                return RedirectToAction(nameof(Index));
            }
        }
        return View(employeeDto);
    }

    public IActionResult Update(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        EmployeeDto? employee = _employeeService.GetEmployeeById(id.Value);
        if (employee == null)
        {
            return NotFound();
        }
        return View(employee);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(int id, EmployeeDto employeeDto)
    {
        if (id != employeeDto.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            if (_employeeService.UpdateEmpoyee(employeeDto))
            {
                TempData["Success Message"] = "Employee updated successfully";
                return RedirectToAction(nameof(Index));
            }
        }
        return View(employeeDto);
    }

    public IActionResult Delete(int? id)
    {
        if (id == null) return NotFound();
        var employee = _employeeService.GetEmployeeById(id.Value);
        if (employee == null) return NotFound();
        return View(employee);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        if (_employeeService.DeleteEmployee(id))
        {
            TempData["SuccessMessage"] = "Employee deleted successfully.";
        }
        else
        {
            TempData["ErrorMessage"] = "Failed to delete employee.";
        }
        return RedirectToAction(nameof(Index));
    }
}
