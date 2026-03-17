using System;
using System.Collections.Generic;
using System.Text;
using WorkLogic_HR.Core.DTO;

namespace WorkLogic_HR.Core.ServiceContracts;

public interface IEmployeeService
{
    public List<EmployeeDto> GetAllEmployees();
    public EmployeeDto? GetEmployeeById(int id);
    public bool CreateEmployee(EmployeeDto employee);
    public bool UpdateEmpoyer(EmployeeDto employee);
    public bool DeleteEmployee(int id);
    List<EmployeeDto> FilerEmployees(Func<EmployeeDto,bool> filter);


}
