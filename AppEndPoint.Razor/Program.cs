using AppDomainAppService;
using AppDomainCore.Contract.Car;
using AppDomainCore.Contract.OldCar;
using AppDomainCore.Contract.TechnicalExamination;
using AppDomainCore.Contract.User;
using AppDomainCore.Entities.Config;
using AppDomainService;
using AppInfraDataAccessEf.Repositories;
using AppInfraDbSqlServer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();





//var congiguration = new ConfigurationBuilder().AddJsonFile("appsettings").Build();
//var siteSetting = congiguration.GetSection(nameof(SiteSetting)).Get<SiteSetting>();
//builder.Services.AddSingleton(siteSetting);




builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();

builder.Services.AddScoped<ITechnicalExaminationRepository, TechnicalExaminationRepository>();
builder.Services.AddScoped<ITechnicalExaminationService, TechnicalExaminationService>();
builder.Services.AddScoped<ITechnicalExaminationAppService, TechnicalExaminationAppService>();

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarAppService, CarAppservice>();

builder.Services.AddScoped<IOldCarRepository, OldCarRepository>();
builder.Services.AddScoped<IOldCarService, OldCarService>();
builder.Services.AddScoped<IOldCarAppService, OldCarAppService>();


builder.Services.AddDbContext<AppDbContext>();


// Add services to the container.
builder.Services.AddRazorPages();


//builder.Services.AddDbContext<AppDbContext>(option =>
//    option.UseSqlServer(siteSetting.ConnectionString.SqlConnection));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
