using WorkLogic_HR.Core.Domain.Entities;
using WorkLogic_HR.Core.Domain.RepositoryContracts;
using WorkLogic_HR.Infrastucture.Repository.IRepository;

namespace WorkLogic_HR.Infrastucture.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    //public readonly SampleData _sampleData;
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        //_sampleData = new SampleData();
        _context = context;
    }

    public List<Employee> GetAll()
    {
        return _context.Employees.OrderBy(e => e.Name).ToList();
    }

    public Employee? GetById(int id)
    {
        return _context.Employees.FirstOrDefault(e => e.Id == id);
    }

    public void Create(Employee entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        _context.Employees.Add(entity);
    }

    public void Update(Employee entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        //List<Employee> employees = _sampleData.GetSampleEmployees();
        Employee? employee = _context.Employees.Find(entity.Id);

        if (employee != null)
        {
            employee.Name = entity.Name;
            employee.Email = entity.Email;
            employee.JobPosition = entity.JobPosition;
        }
    }

    public bool Delete(int id)
    {
        //List<Employee> employees = _sampleData.GetSampleEmployees();

        Employee? employee = _context.Employees.Find(id);

        if (employee != null)
        {
            _context.Employees.Remove(employee);
            return true;
        }

        return false;
    }

    public bool Save()
    {
        try
        {
            //_sampleData.GetSampleEmployees().SaveChanges();
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
