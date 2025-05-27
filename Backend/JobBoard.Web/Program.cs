using FluentValidation;
using FluentValidation.AspNetCore;
using JobBoard.Application.Features;
using JobBoard.Application.Validators;
using JobBoard.Application.Validators.AuthDTOs;
using JobBoard.Infrastructure;
using JobBoard.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace JobBoard.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDbContext<JobBoardDbContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString, optBuilder =>
            {
                optBuilder.MigrationsAssembly(typeof(JobBoardDbContext).Assembly.GetName().Name);
            });
        });

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(3);
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
                options.Events.OnRedirectToAccessDenied = context =>
                {
                    context.Response.StatusCode = 403;
                    return Task.CompletedTask;
                };

            });

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("cookieAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Name = "Cookie",
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                In = Microsoft.OpenApi.Models.ParameterLocation.Cookie,
                Description = "Cookie-based authentication (e.g., .AspNetCore.Cookies)"
            });

            options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
            {
                {
                    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Reference = new Microsoft.OpenApi.Models.OpenApiReference
                        {
                            Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "cookieAuth"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        builder.Services.AddControllers();

        builder.Services.AddValidatorsFromAssemblyContaining<LoginRequestValidation>();
        builder.Services.AddFluentValidationAutoValidation();

        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromHours(1);
            //options.Cookie.HttpOnly = true;
            //options.Cookie.IsEssential = true;
        });

        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IEditProfileService, EditProfileService>();
        builder.Services.AddScoped<IVacancyService, VacancyService>();
        builder.Services.AddScoped<ICompanyService, CompanyService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseStaticFiles();
        //app.UseHttpsRedirection();

        app.UseRouting();

        app.UseSession();
        app.UseAuthentication();
        app.UseAuthorization();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<JobBoardDbContext>();
            DbInitializer.Seed(context);
        }

        app.MapControllers();

        app.Run();
    }
}