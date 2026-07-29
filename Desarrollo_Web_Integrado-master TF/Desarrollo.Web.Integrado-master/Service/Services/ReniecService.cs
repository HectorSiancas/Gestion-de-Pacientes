using System.Text.Json;

namespace Service.Services
{
    public class ReniecService
    {
        private readonly HttpClient httpClient;

        public ReniecService(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient("RENIEC");
        }

        private JsonSerializerOptions OpcionesPorDefectoJSON => new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public async Task<Persona> ConsumirServicioAsync(int dni)
        {
            //string url = $"https://api.apis.net.pe/v2/reniec/dni?numero={dni}";
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"dni?numero={dni}");
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
