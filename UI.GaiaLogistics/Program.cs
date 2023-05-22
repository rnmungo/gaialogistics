using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Contracts.GaiaLogistics.Services;
using Contracts.GaiaLogistics.UnitOfWork;
using BLL.GaiaLogistics.Services;
using DAL.GaiaLogistics;
using DAL.GaiaLogistics.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

// Add AutoMapper
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new BLL.GaiaLogistics.Mappers.Mapper());
    mc.AddProfile(new UI.GaiaLogistics.Mappers.Mapper());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton(mapper);

// Add DbContext
builder.Services.AddDbContext<AppDbContext>
(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DB_GAIA_CONNECTION_STRING") ?? "").EnableSensitiveDataLogging();
        options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole().AddDebug()));
    }
);

// Add UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add Business Services
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IStockMovementService, StockMovementService>();
builder.Services.AddScoped<IStockMovementReportingService, StockMovementReportingService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
