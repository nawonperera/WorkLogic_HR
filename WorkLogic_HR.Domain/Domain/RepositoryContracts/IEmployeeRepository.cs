using System;
using System.Collections.Generic;
using System.Text;
using WorkLogic_HR.Core.Domain.Entities;
using WorkLogic_HR.Infrastucture.Repository.IRepository;

namespace WorkLogic_HR.Core.Domain.RepositoryContracts;

public interface IEmployeeRepository : IRepository<Employee>
{

}
