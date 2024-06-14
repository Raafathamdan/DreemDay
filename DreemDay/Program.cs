using DreemDay_Core.Context;
using DreemDay_Core.IRepository;
using DreemDay_Core.Iservice;
using DreemDay_Infra.Repository;
using DreemDay_Infra.Service;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Dreem Day",
        Version = "v1",
        Description = "An API to Management Wedding Hall Reservation And Car Rental ",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Raafat Hamdan",
            Email = "raafat19967@outlook.com",
            Url = new Uri("https://twitter.com/jwalkner"),
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
}); builder.Services.AddDbContext<DreemDayDbContext>(x => x.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnection"), b => b.MigrationsAssembly("DreemDay")));

// Register Repositories
builder.Services.AddScoped<IAuthRepos, AuthRepos>();
builder.Services.AddScoped<IUserRepos, UserRepos>();
builder.Services.AddScoped<ILoginRepos, LoginRepos>();
builder.Services.AddScoped<IOrderRepos, OrderRepos>();
builder.Services.AddScoped<IPaymentRepos, PaymentRepos>();
builder.Services.AddScoped<ICartItemRepos, CartItemRepos>();
builder.Services.AddScoped<IServiceProviderRepos, ServiceProviderRepos>();
builder.Services.AddScoped<IServiceRepos, ServiceRepos>();
builder.Services.AddScoped<ICartRepos, CartRepos>();
builder.Services.AddScoped<ICategoryRepos, CategoryRepos>();
builder.Services.AddScoped<IWishListRepos, WishListRepos>();

// Register Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<ICartItemService, CartItemService>();
builder.Services.AddScoped<IServiceProviderService, ServiceProviderService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IWishListService, WishListService>();
// Serilog
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).
               WriteTo.File(configuration.GetValue<string>("LoggerFilePath")
                , rollingInterval: RollingInterval.Day).MinimumLevel.Debug().
                CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();

