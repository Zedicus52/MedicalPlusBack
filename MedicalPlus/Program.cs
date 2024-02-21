using System.Text;
using DataAccessEF.Data;
using DataAccessEF.Repositories;
using DataAccessEF.UnitOfWorks;
using Domain.Interfaces;
using Domain.Interfaces.UnitOfWorks;
using Domain.Models;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ConfigurationManager = MedicalPlus.ConfigurationManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("V1", new OpenApiInfo
    {
        Version = "V1",
        Title = "Medical Plus WEB API",
        Description = ""
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List < string > ()
        }
    });
});

builder.Services.AddTransient(typeof(IGenericRepo<,>), typeof(GenericRepo<,>));
builder.Services.AddTransient<IActionRepo, ActionRepo>();
builder.Services.AddTransient<IDifficultyRepo, DifficultyRepo>();
builder.Services.AddTransient<IFioRepo, FioRepo>();
builder.Services.AddTransient<IGenderRepo, GenderRepo>();
builder.Services.AddTransient<ILogRepo, LogRepo>();
builder.Services.AddTransient<IPatientRepo, PatientRepo>();
builder.Services.AddTransient<IProblemRepo, ProblemRepo>();
builder.Services.AddTransient<IUserRepo, UserRepo>();
builder.Services.AddTransient<IUnitOfWorks, UnitOfWorks>();

builder.Services.AddDbContext<MedicalPlusDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Local"),
        b => b.MigrationsAssembly(typeof(MedicalPlusDbContext).Assembly.FullName)));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<MedicalPlusDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(opt => 
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    
}).AddJwtBearer(options => 
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = ConfigurationManager.AppSettings["JWT:ValidIssuer"],
        
        ValidateAudience = true,
        ValidAudience = ConfigurationManager.AppSettings["JWT:ValidAudience"],
        
        ValidateLifetime = true,
        
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["JWT:Secret"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/V1/swagger.json", "Medical Plus WebAPI");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.Run();
