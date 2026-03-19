using WorkLogic_HR.Core.Domain.Entities;
using WorkLogic_HR.Core.Domain.RepositoryContracts;
using WorkLogic_HR.Core.DTO;
using WorkLogic_HR.Core.Helpers;
using WorkLogic_HR.Core.ServiceContracts;

namespace WorkLogic_HR.Core.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly CacheHelper _cacheHelper;

    public EmployeeService(IEmployeeRepository employeeRespository, CacheHelper cacheHelper)
    {
        _employeeRepository = employeeRespository;
        _cacheHelper = cacheHelper;
    }
    public bool CreateEmployee(EmployeeDto employee)
    {
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee));
        }
        _cacheHelper.RemoveCache("Get_Employees");

        Employee person = MapToEntity(employee);

        _employeeRepository.Create(person);
        
        return _employeeRepository.Save();
    }

    public bool DeleteEmployee(int id)
    {
        if (id <= 0)
        {
            return false;
        }
        _cacheHelper.RemoveCache("Get_Employees");
        Employee? person = _employeeRepository.GetById(id);
        if(person == null)
        {
            return false;
        }
        _employeeRepository.Delete(id);
        return _employeeRepository.Save();
    }

    public List<EmployeeDto> FilerEmployees(Func<EmployeeDto, bool> filter)
    {
        
        return GetAllEmployees().Where(filter).ToList();
    }

    public List<EmployeeDto> GetAllEmployees()
    {
        return _cacheHelper.Cached("Get_Employees", () =>
        {
            return _employeeRepository.GetAll().Select(e => MapToDto(e)).ToList();
        });
        
    }

    public EmployeeDto? GetEmployeeById(int id)
    {
        if (id <= 0)
        {
            return null;
        }
        Employee? employee = _employeeRepository.GetById(id);

        if (employee == null)
            return null;

        return MapToDto(employee);
    }

    public bool UpdateEmpoyee(EmployeeDto employee)
    {
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee));
        }
        _cacheHelper.RemoveCache("Get_Employees");

        Employee person = MapToEntity(employee);

        _employeeRepository.Update(person);
        return _employeeRepository.Save();
    }

    //Helper methods to Employee to EmployeeDto Viseversa (We can use automapper for this. since there is few properties here I am using this)

    private EmployeeDto MapToDto(Employee employee)
    {
        return new EmployeeDto
        {
            Id = employee.Id,
            Name = employee.Name,
            Email = employee.Email,
            JobPosition = employee.JobPosition,
        };
    }

    private Employee MapToEntity(EmployeeDto employeeDto)
    {
        return new Employee
        {
            Id = employeeDto.Id,
            Name = employeeDto.Name,
            Email = employeeDto.Email,
            JobPosition = employeeDto.JobPosition
        };
    }
}
