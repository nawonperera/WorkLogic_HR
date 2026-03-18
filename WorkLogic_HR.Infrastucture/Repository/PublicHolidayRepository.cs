using WorkLogic_HR.Core.Domain.Entities;
using WorkLogic_HR.Core.Domain.RepositoryContracts;
using WorkLogic_HR.Infrastucture.Repository.IRepository;

namespace WorkLogic_HR.Infrastucture.Repository;

public class PublicHolidayRepository : IPublicHolidayRepository
{
    private readonly ApplicationDbContext _context;

    public PublicHolidayRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public void Create(PublicHolidays entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        _context.PublicHolidays.Add(entity);
    }

    public bool Delete(int id)
    {
        PublicHolidays? holiday = _context.PublicHolidays.Find(id);
        if (holiday != null)
        {
            _context.PublicHolidays.Remove(holiday);
            return true;
        }
        return false;
    }

    public List<PublicHolidays> GetAll()
    {
        return _context.PublicHolidays.OrderBy(x => x.Date).ToList();
    }

    public PublicHolidays? GetById(int id)
    {
        return _context.PublicHolidays.FirstOrDefault(x => x.Id == id);
    }

    public bool Save()
    {
        try
        {
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public void Update(PublicHolidays entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        PublicHolidays? holiday = _context.PublicHolidays.Find(entity.Id);

        if (holiday != null)
        {
            holiday.Name = entity.Name;
            holiday.Date = entity.Date;
        }
    }

    public List<PublicHolidays> GetSelectedHolidays(DateTime startDate, DateTime endDate)
    {
        return _context.PublicHolidays
            .Where(x => x.Date >= startDate.Date && x.Date <= endDate.Date)
            .OrderBy(h => h.Date)
            .ToList();
    }
}
