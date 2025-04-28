
using Domain.Contracts;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;
using Persistence.Identity.Persistence.Identity;
using Persistence.Repositories;
using Services;
using Services.Abstractions;
using Services.MapingProfiles;
using Shared.IdentityDtos;
using Shared.Middleware;
using StackExchange.Redis;
using Store.Api.Extensions;
using Store.Api.Factories;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace Store.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //builder.Services.AddControllers();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddCoreServices(builder.Configuration);
            builder.Services.AddPresentationServices();


            //builder.Services.AddTransient<PictureUrlResolver>();
            //builder.Services.AddAutoMapper(typeof(AssemblyReference).Assembly);
            //builder.Services.AddAutoMapper(x=>x.AddProfile(new ProductProfile()));
            





            var app = builder.Build();
            await app.SeedDbAsync();

            app.UseMiddleware<GlobalErrorHandlingMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
