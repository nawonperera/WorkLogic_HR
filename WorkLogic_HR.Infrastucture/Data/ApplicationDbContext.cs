using Microsoft.EntityFrameworkCore;
using WorkLogic_HR.Core.Domain.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<PublicHolidays> PublicHolidays { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
            entity.Property(e => e.JobPosition).IsRequired().HasMaxLength(100);
        });
        modelBuilder.Entity<PublicHolidays>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Date).IsRequired();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
        });

        modelBuilder.Entity<PublicHolidays>().HasData(
                new PublicHolidays { Id = 1, Date = new DateTime(2025, 1, 1), Name = "New Year's Day" },
                new PublicHolidays { Id = 2, Date = new DateTime(2025, 1, 14), Name = "Pongal / Makar Sankranti" },
                new PublicHolidays { Id = 3, Date = new DateTime(2025, 1, 26), Name = "Republic Day" },
                new PublicHolidays { Id = 4, Date = new DateTime(2025, 3, 14), Name = "Holi" },
                new PublicHolidays { Id = 5, Date = new DateTime(2025, 4, 14), Name = "Ambedkar Jayanti" },
                new PublicHolidays { Id = 6, Date = new DateTime(2025, 4, 18), Name = "Good Friday" },
                new PublicHolidays { Id = 7, Date = new DateTime(2025, 5, 1), Name = "May Day" },
                new PublicHolidays { Id = 8, Date = new DateTime(2025, 8, 15), Name = "Independence Day" },
                new PublicHolidays { Id = 9, Date = new DateTime(2025, 10, 2), Name = "Gandhi Jayanti" },
                new PublicHolidays { Id = 10, Date = new DateTime(2025, 10, 20), Name = "Diwali" },
                new PublicHolidays { Id = 11, Date = new DateTime(2025, 12, 25), Name = "Christmas Day" },
                new PublicHolidays { Id = 12, Date = new DateTime(2026, 1, 1), Name = "New Year's Day" },
                new PublicHolidays { Id = 13, Date = new DateTime(2026, 1, 26), Name = "Republic Day" },
                new PublicHolidays { Id = 14, Date = new DateTime(2026, 3, 4), Name = "Holi" },
                new PublicHolidays { Id = 15, Date = new DateTime(2026, 4, 3), Name = "Good Friday" },
                new PublicHolidays { Id = 16, Date = new DateTime(2026, 4, 14), Name = "Ambedkar Jayanti" },
                new PublicHolidays { Id = 17, Date = new DateTime(2026, 5, 1), Name = "May Day" },
                new PublicHolidays { Id = 18, Date = new DateTime(2026, 8, 15), Name = "Independence Day" },
                new PublicHolidays { Id = 19, Date = new DateTime(2026, 10, 2), Name = "Gandhi Jayanti" },
                new PublicHolidays { Id = 20, Date = new DateTime(2026, 12, 25), Name = "Christmas Day" }
            );
    }
}

