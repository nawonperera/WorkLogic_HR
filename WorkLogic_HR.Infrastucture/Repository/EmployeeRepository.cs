using WorkLogic_HR.Infrastucture.Repository.IRepository;

namespace WorkLogic_HR.Infrastucture.Repository;

public class EmployeeRepository : IRepository<Employee>
{
    public readonly SampleData _sampleData;

    public EmployeeRepository()
    {
        _sampleData = new SampleData();
    }

    public List<Employee> GetAll()
    {
        return _sampleData.GetSampleEmployees().OrderBy(e => e.Name).ToList();
    }

    public Employee? GetById(int id)
    {
        return _sampleData.GetSampleEmployees().FirstOrDefault(e => e.Id == id);
    }

    public void Create(Employee entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        _sampleData.GetSampleEmployees().Add(entity);
    }

    public void Update(Employee entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        List<Employee> employees = _sampleData.GetSampleEmployees();

        Employee? employee = employees.Find(e => e.Id == entity.Id);

        if (employee != null)
        {
            employee.Name = entity.Name;
            employee.Email = entity.Email;
            employee.JobPosition = entity.JobPosition;
        }
    }

    public bool Delete(int id)
    {
        List<Employee> employees = _sampleData.GetSampleEmployees();

        Employee? employee = employees.Find(e => e.Id == id);

        if (employee != null)
        {
            employees.Remove(employee);
            return true;
        }

        return false;
    }

    public void Save()
    {
        //_sampleData.GetSampleEmployees().SaveChanges();
    }
}
