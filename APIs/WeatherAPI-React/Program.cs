using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;

namespace WeatherAPI_React
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddSingleton<ApiCounter>(); // Use AddSingleton to create a shared instance

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost", builder =>
                {
                    builder.WithOrigins("http://localhost:5173") // Change this to match your React app's URL
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("AllowLocalhost"); // Apply the CORS policy

            app.UseAuthorization();

            var counter = app.Services.GetRequiredService<ApiCounter>();

            app.MapGet("/weather/APIcounter", () =>
            {
                var count = counter.GetCount();
                var result = new { Count = count };
                return Results.Json(result, contentType: "application/json");
            });

            app.MapGet("/weather", async () =>
            {
                using var client = new HttpClient();

                var apiKey = configuration["WeatherAPIKey"];

                var response = await client.GetAsync($"http://api.weatherapi.com/v1/current.json?key={apiKey}&q=stockholm");
                var content = await response.Content.ReadAsStringAsync();

                counter.IncrementCount();
                return Results.Content(content, contentType: "application/json");
            });

            app.MapGet("/weather/{city}", async (string city) =>
            {
                using var client = new HttpClient();

                var apiKey = configuration["WeatherAPIKey"];

                var response = await client.GetAsync($"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}");
                var content = await response.Content.ReadAsStringAsync();

                counter.IncrementCount();
                return Results.Content(content, contentType: "application/json");
            });

            app.MapGet("/api/myapi/hello", () =>
            {
                return Results.Text("Hello from My API!");
            });

            app.Run();
        }
    }
}
