using DreemDay_Core.Context;
using DreemDay_Core.IRepository;
using DreemDay_Core.Iservice;
using DreemDay_Infra.Repository;
using DreemDay_Infra.Service;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using System.Text;

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
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT token into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] { }
    }});
}); 
builder.Services.AddDbContext<DreemDayDbContext>(x => x.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnection"), b => b.MigrationsAssembly("DreemDay")));

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
builder.Services.AddCors(opt=>
{
    opt.AddPolicy(name: "default", builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
var key = Encoding.ASCII.GetBytes("x3Fv8tB7p9r4q3N7Q1Z2W3M5P6L8K0J3H2G5F6D7S9A8V7C6X5Z1Y2E4R1T3Y4U7");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ClockSkew = TimeSpan.Zero
    };
});
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
var imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Images");
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(imageDirectory),
    RequestPath = "/Images"
}) ;
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("default");
app.MapControllers();
app.Run();

