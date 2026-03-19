using Microsoft.EntityFrameworkCore;
using WorkLogic_HR.Core.Domain.RepositoryContracts;
using WorkLogic_HR.Core.Helpers;
using WorkLogic_HR.Core.ServiceContracts;
using WorkLogic_HR.Core.Services;
using WorkLogic_HR.Infrastucture.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();
//added Addsingleton because same cache use everywhere from the start.
builder.Services.AddSingleton<CacheHelper>();

builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection")));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IPublicHolidayRepository, PublicHolidayRepository>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IPublicHolidayServiec, PublicHolidayService>();
builder.Services.AddScoped<IWorkingDaysService, WorkingDaysService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");


app.Run();
