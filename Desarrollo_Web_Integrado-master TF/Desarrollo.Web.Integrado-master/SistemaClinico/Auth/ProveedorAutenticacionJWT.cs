using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using SistemaClinico.Helpers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace SistemaClinico.Auth
{
    public class ProveedorAutenticacionJWT : AuthenticationStateProvider, ILoginService
    {
        public static readonly string TOKENKEY = "TOKENKEY";
        public static readonly string EXPIRATIONTOKENKEY = "EXPIRATIONTOKENKEY";
        public static readonly string ExpiracionMinutos = "ExpiracionMinutos";
        private AuthenticationState Anonimo => new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        private readonly IJSRuntime js;
        //private readonly HttpClient httpClient;
        //private readonly IRepositorio repositorio;
        public ProveedorAutenticacionJWT(IJSRuntime js)
        {
            this.js = js;
            //this.httpClient = httpClient;
            //this.repositorio = repositorio;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await js.GetFromLocalStorage(TOKENKEY);

            if (string.IsNullOrEmpty(token))
            {
                return Anonimo;
            }

            return ConstruirAuthenticationState(token);
        }

        public AuthenticationState ConstruirAuthenticationState(string token)
        {
            var usuarioAutenticado = new ClaimsIdentity(
                  new List<Claim>
                  {
                    new Claim("Nombre", "Juan"),
                    new Claim("edad", "30"),
                    new Claim(ClaimTypes.Name, token),
                     new Claim(ClaimTypes.Role, token)
                  },
                  authenticationType: "prueba");

            var x = new ClaimsIdentity(new List<Claim>()
            {
                new Claim("","")

            }, authenticationType: "prueba");


            return new AuthenticationState(new ClaimsPrincipal(usuarioAutenticado));
        }

        public async Task Login(UserToken userToken)
        {
            await js.SetInLocalStorage(TOKENKEY, userToken.Token);
            var authState = ConstruirAuthenticationState(userToken.Token);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public async Task Logout()
        {
            await Limpiar();
            NotifyAuthenticationStateChanged(Task.FromResult(Anonimo));
        }

        public async Task ManejarRenovacionToken()
        {
            //Implementar refreshToken
        }

        private async Task Limpiar()
        {
            await js.RemoveItem(TOKENKEY);
            await js.RemoveItem(EXPIRATIONTOKENKEY);
            await js.RemoveItem(ExpiracionMinutos);
            //httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
