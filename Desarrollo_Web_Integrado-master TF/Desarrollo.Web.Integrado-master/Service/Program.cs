
using Scalar.AspNetCore;
using Service.Services;

namespace Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region My Added Code
            builder.Services.AddHttpClient<ReniecService>("RENIEC", client =>
            {
                client.BaseAddress = new Uri("https://api.apis.net.pe/v2/reniec/");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "apis-token-11955.RvOjyAQLT2xTSMW6EvAdbhRPX763B1hv");
            });
            builder.Services.AddScoped<ReniecService>();
            #endregion

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options =>
                {                   
                    options.Title = "My API";
                    options.ShowSidebar = true;
                });
            }
            else
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options =>
                {
                    options.Title = "My API - Grupo 6";
                    options.ShowSidebar = true;
                });
            }

            app.UseCors(config =>
            {
                config.AllowAnyOrigin();
                config.AllowAnyMethod();
                config.AllowAnyHeader();
                config.WithExposedHeaders("*");
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
