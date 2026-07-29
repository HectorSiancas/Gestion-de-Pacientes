using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using SistemaClinico.Helpers;

namespace SistemaClinico.Services
{
    public class Service : IService
    {
        private readonly HttpClient httpClient;
        private readonly IJSRuntime js;
        private readonly string BaseUrl;

        public Service(HttpClient httpClient, IConfiguration configuration, IJSRuntime js)
        {
            this.httpClient = httpClient;
            this.js = js;
            //BaseUrl = configuration["Api:sigcp"];

            BaseUrl = $"https://japisistemas-c3hsfydjcvbrb6ec.eastus-01.azurewebsites.net/";
        }

        private JsonSerializerOptions OpcionesPorDefectoJSON => new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        private JsonSerializerOptions options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        public async Task<HttpResponseWrapper<T>> Get<T>(string url)
        {
            var tokenApi = await js.GetFromLocalStorage("TOKENAPI");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", tokenApi);

            var responseHTTP = await httpClient.GetAsync($"{BaseUrl}{url}");

            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = await DeserializarRespuesta<T>(responseHTTP, OpcionesPorDefectoJSON);
                return new HttpResponseWrapper<T>(response, false, responseHTTP);
            }
            else
            {
                return new HttpResponseWrapper<T>(default, true, responseHTTP);
            }
        }

        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar, options);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PostAsync($"{BaseUrl}{url}", enviarContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar, options);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PutAsync($"{BaseUrl}{url}", enviarContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar, options);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PostAsync($"{BaseUrl}{url}", enviarContent);
            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await DeserializarRespuesta<TResponse>(responseHttp, OpcionesPorDefectoJSON);
                return new HttpResponseWrapper<TResponse>(response, false, responseHttp);
            }
            else
            {
                return new HttpResponseWrapper<TResponse>(default, true, responseHttp);
            }
        }

        public async Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar, options);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PutAsync($"{BaseUrl}{url}", enviarContent);
            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await DeserializarRespuesta<TResponse>(responseHttp, OpcionesPorDefectoJSON);
                return new HttpResponseWrapper<TResponse>(response, false, responseHttp);
            }
            else
            {
                return new HttpResponseWrapper<TResponse>(default, true, responseHttp);
            }
        }

        public async Task<HttpResponseWrapper<object>> Delete(string url)
        {
            var responseHTTP = await httpClient.DeleteAsync($"{BaseUrl}{url}");
            return new HttpResponseWrapper<object>(null, !responseHTTP.IsSuccessStatusCode, responseHTTP);
        }

        public async Task<HttpResponseWrapper<object>> Patch<T>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar, options);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PatchAsync($"{BaseUrl}{url}", enviarContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        private async Task<T> DeserializarRespuesta<T>(HttpResponseMessage httpResponse, JsonSerializerOptions jsonSerializerOptions)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, jsonSerializerOptions);
        }
    }
}
