﻿using Domain.Contracts;

namespace Store.Api.Extensions
{
    public static class WebApplicationExtension
    {
        public static async Task<WebApplication> SeedDbAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();

            await dbInitializer.InitializeAsync();
            await dbInitializer.InitializeIdentityAsync();

            return app;
        }
    }
}
