using WorkLogic_HR.Core.Domain.Entities;
using WorkLogic_HR.Core.DTO;
using WorkLogic_HR.Core.ServiceContracts;
using WorkLogic_HR.Infrastucture.Repository.IRepository;

namespace WorkLogic_HR.Core.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IRepository<Employee> _employeeRepository;

    public EmployeeService(IRepository<Employee> employeeRespository)
    {
        _employeeRepository = employeeRespository;
    }
    public bool CreateEmployee(EmployeeDto employee)
    {
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee));
        }
            
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
        return _employeeRepository.GetAll().Select(e=>MapToDto(e)).ToList();
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
