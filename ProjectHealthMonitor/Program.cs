
using FluentValidation;
using FluentValidation.AspNetCore;
using ProjectHealthMonitor.Middleware;
using ProjectHealthMonitor.Repositories;
using ProjectHealthMonitor.Repositories.Interfaces;
using ProjectHealthMonitor.Services;
using ProjectHealthMonitor.Services.Interfaces;
using ProjectHealthMonitor.Validation;

namespace ProjectHealthMonitor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IProjectRepository, ProjectRepository>();
            builder.Services.AddScoped<IProjectService, ProjectService>();

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<CreateProjectValidator>();

            var app = builder.Build();
            app.UseMiddleware<ExceptionMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
