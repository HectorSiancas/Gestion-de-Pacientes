using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using SistemaClinico.Auth;
using SistemaClinico.Services;

namespace SistemaClinico
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            #region Radzen
            builder.Services.AddRadzenComponents();
            builder.Services.AddRadzenCookieThemeService(options =>
            {
                options.Name = "DwiTheme";
                options.Duration = TimeSpan.FromDays(365);
            });
            #endregion

            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //builder.Services.AddOidcAuthentication(options =>
            //{
            //    // Configure your authentication provider options here.
            //    // For more information, see https://aka.ms/blazor-standalone-auth
            //    builder.Configuration.Bind("Local", options.ProviderOptions);
            //});

            #region Seguridad
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<ProveedorAutenticacionJWT>();
            builder.Services.AddScoped<AuthenticationStateProvider, ProveedorAutenticacionJWT>(provider => provider.GetRequiredService<ProveedorAutenticacionJWT>());
            builder.Services.AddScoped<ILoginService, ProveedorAutenticacionJWT>(provider => provider.GetRequiredService<ProveedorAutenticacionJWT>());

            //builder.Services.AddAuthorizationCore();
            ////builder.Services.AddScoped<SecurityService>();
            //builder.Services.AddScoped<AuthenticationStateProvider, ProveedorAutenticacionPrueba>();
            ////builder.Services.AddScoped<AuthenticationStateProvider, ApplicationAuthenticationStateProvider>();
            #endregion

            #region Add
            builder.Services.AddScoped<dbService>();
            builder.Services.AddScoped<IService, Service>();
            //builder.Services.AddHttpClient("RENIEC", client => client.BaseAddress = new Uri("https://api.apis.net.pe/v2/reniec/"));
            builder.Services.AddHttpClient<ReniecService>("RENIEC", client =>
            {
                //client.BaseAddress = new Uri("https://api.apis.net.pe/v2/reniec/");
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "apis-token-11955.RvOjyAQLT2xTSMW6EvAdbhRPX763B1hv");

                client.BaseAddress = new Uri("https://capiclinica-f0geggd6f4fweec3.canadacentral-01.azurewebsites.net/");
            });
            builder.Services.AddScoped<ReniecService>();

            #endregion

            await builder.Build().RunAsync();
        }
    }
}
