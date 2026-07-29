using System.Net.Http;

namespace SistemaClinico.Services
{
    public class ReniecService
    {
        private readonly HttpClient httpClient;

        public ReniecService(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient("RENIEC");
        }

        private System.Text.Json.JsonSerializerOptions OpcionesPorDefectoJSON => new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public async Task<Persona> ConsumirServicioAsync(string dni)
        {
            //string url = $"https://api.apis.net.pe/v2/reniec/dni?numero={dni}";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"api/Reniec/dni?numero={dni}");
                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    var persona = System.Text.Json.JsonSerializer.Deserialize<Persona>(responseData, OpcionesPorDefectoJSON);
                    return persona;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        public class Persona
        {
            public string Nombres { get; set; }
            public string ApellidoPaterno { get; set; }
            public string ApellidoMaterno { get; set; }
            public string TipoDocumento { get; set; }
            public string NumeroDocumento { get; set; }
            public string DigitoVerificador { get; set; }
        }
    }
}
