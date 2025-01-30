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
using Scalar.AspNetCore;
internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);




        var congiguration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var siteSetting = congiguration.GetSection(nameof(SiteSetting)).Get<SiteSetting>();
        builder.Services.AddSingleton(siteSetting);

        builder.Services.AddDbContext<AppDbContext>(option =>
            option.UseSqlServer(siteSetting.ConnectionString.SqlConnection)
        );




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





        // Add services to the container.

        builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

// Configure the HTTP request pipeline.
// Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
