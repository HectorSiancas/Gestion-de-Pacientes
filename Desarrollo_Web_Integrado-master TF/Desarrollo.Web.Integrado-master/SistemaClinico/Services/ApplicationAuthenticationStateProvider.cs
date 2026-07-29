using Microsoft.AspNetCore.Components.Authorization;
using SistemaClinico.Models;
using System.Security.Claims;

namespace SistemaClinico.Services
{
    public class ApplicationAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly SecurityService securityService;
        private ApplicationAuthenticationState authenticationState;

        public ApplicationAuthenticationStateProvider(SecurityService securityService)
        {
            this.securityService = securityService;
        }

        //public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        //{
        //    var anonimo = new ClaimsIdentity();

        //    var usuarioAutenticado = new ClaimsIdentity(
        //          new List<Claim>
        //          {
        //            new Claim("Nombre", "Juan"),
        //            new Claim("edad", "30"),
        //            new Claim(ClaimTypes.Name, "user@policia.gob.pe"),
        //             new Claim(ClaimTypes.Role, "admin")
        //          },
        //          authenticationType: "prueba");



        //    var x = new ClaimsIdentity(new List<Claim>()
        //    {
        //        new Claim("","")

        //    }, authenticationType: "prueba");


        //    return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(usuarioAutenticado)));
        //}

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();

            try
            {
                var state = await GetApplicationAuthenticationStateAsync();

                if (state.IsAuthenticated)
                {
                    identity = new ClaimsIdentity(state.Claims.Select(c => new Claim(c.Type, c.Value)), "Dwi.Server");
                }
            }
            catch (HttpRequestException ex)
            {
            }

            var result = new AuthenticationState(new ClaimsPrincipal(identity));

            await securityService.InitializeAsync(result);

            return result;
        }

        private async Task<ApplicationAuthenticationState> GetApplicationAuthenticationStateAsync()
        {
            if (authenticationState == null)
            {
                authenticationState = await securityService.GetAuthenticationStateAsync();
            }

            return authenticationState;
        }
    }
}
