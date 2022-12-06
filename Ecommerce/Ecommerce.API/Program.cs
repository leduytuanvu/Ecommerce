using Ecommerce.API;
using Ecommerce.API.Common.Middleware;
using Ecommerce.Application;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ADD MAPPER AND CONTROLLER
builder.Services.AddPresentation();

// ADD DEPENDENCY INJECTION OF APPLICATION
builder.Services.AddApplication();

// ADD DEPENDENCY INJECTION OF INFRASTRUCTURE
builder.Services.AddInfrastructure(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// SET UP JWT
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecommerce", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",
                }
            },
            new string[]{}
        }

    });
});

// SET UP JWT =============== NOT SURE
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Secret"]))
    };
});

// SET UP CORS
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

// SET UP DBCONTEXT
builder.Services.AddDbContext<EcommerceDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("Ecommerce"),
        b => b.MigrationsAssembly("Ecommerce.API")
    ), ServiceLifetime.Singleton
);

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("C:\\leduytuanvu\\development\\dotnet\\Ecommerce\\Ecommerce.API\\Logs\\log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline && SET UP SWAGGER
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DemoJWTToken v1"));
}

// SET UP ERROR HANDING MIDDLEWARE
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

// SET UP JWT
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
