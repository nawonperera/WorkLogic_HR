using WorkLogic_HR.Core.Domain.Entities;

namespace WorkLogic_HR.Infrastucture;

//I have created the following sample data from CHATGPT
public  class SampleData
{
    public  List<Employee> GetSampleEmployees()
    {
        return new List<Employee>
            {
                new Employee { Id = 1, Name = "Alice Johnson", Email = "alice.j@example.com", JobPosition = "Software Engineer" },
                new Employee { Id = 2, Name = "Bob Smith", Email = "bob.s@example.com", JobPosition = "Product Manager" },
                new Employee { Id = 3, Name = "Charlie Brown", Email = "charlie.b@example.com", JobPosition = "QA Analyst" },
                new Employee { Id = 4, Name = "Diana Prince", Email = "diana.p@example.com", JobPosition = "DevOps Engineer" },
                new Employee { Id = 5, Name = "Ethan Hunt", Email = "ethan.h@example.com", JobPosition = "Security Specialist" }
            };
    }
    
    public  List<PublicHolidays> GetSamplePublicHolidays()
    {
        int currentYear = DateTime.Now.Year;
        return new List<PublicHolidays>
            {
                new PublicHolidays { Id = 1, Date = new DateTime(currentYear, 1, 1), Name = "New Year's Day" },
                new PublicHolidays { Id = 2, Date = new DateTime(currentYear, 12, 25), Name = "Christmas Day" },
                new PublicHolidays { Id = 3, Date = new DateTime(currentYear, 5, 1), Name = "May Day" },
                new PublicHolidays { Id = 4, Date = new DateTime(currentYear, 8, 15), Name = "Independence Day" },
                new PublicHolidays { Id = 5, Date = new DateTime(currentYear, 10, 2), Name = "Gandhi Jayanti" }
            };
    }

    
    
}
