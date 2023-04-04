using Microsoft.AspNetCore.Cors;
using FinalProjectASP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using FinalProjectASP.Logic;
using Microsoft.Extensions.Options;

namespace FinalProjectASP
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options => options.AddPolicy("Cors", builder =>
            {
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            }));

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200");
                    });
            });

            builder.Services.AddDbContext<DataContext>(options =>
            options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("myAirport")));

            builder.Services.AddScoped<ILogicLegs ,LogicLegs>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}