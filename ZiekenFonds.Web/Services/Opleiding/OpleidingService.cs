using Newtonsoft.Json;
using System.Text;
using ZiekenFonds.Web.DTOS.Opleiding;

namespace ZiekenFonds.Web.Services.Opleiding
{
    public class OpleidingService : IOpleidingServices
    {
        // Service moet de locatie van de api kennen
        private string baseUrl = "https://localhost:7027/api/Opleiding";

        private string apiMonitorUrl = "https://localhost:7027/Monitor";

        public async Task CreateOpleidingAsync(CreateOpleidingPageDto dto)
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonContent = JsonConvert.SerializeObject(dto);
                HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync($"{baseUrl}/CreateOpleiding", httpContent);
            }
        }

        public async Task DeleteOpleiding(int id)
        {
            // Validate input
            if (id <= 0)
            {
                throw new ArgumentException("Invalid ID", nameof(id));
            }

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync($"{baseUrl}/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error deleting Opleiding (Status {response.StatusCode}): {errorMessage}");
                }
            }
        }

        public async Task<OpleidingOphalenDto[]> GetAllOpleidingenAsync()
        {
            // Alle communicatie via API's verloopt via een Http Client
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{baseUrl}/GetAll");

                if (response.IsSuccessStatusCode)
                {
                    // API geven data bijna altijd in JSON Get AKA een string
                    string responseData = await response.Content.ReadAsStringAsync();

                    // TODO
                    OpleidingOphalenDto[] dto = JsonConvert.DeserializeObject<OpleidingOphalenDto[]>(responseData);
                    return dto;
                }

                return null;
            }
        }

        public async Task<OpleidingMonitorPageDto[]> GetAllMonitorsAsync()
        {
            // Alle communicatie via API's verloopt via een Http Client
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiMonitorUrl}");

                if (response.IsSuccessStatusCode)
                {
                    // API geven data bijna altijd in JSON Get AKA een string
                    string responseData = await response.Content.ReadAsStringAsync();

                    // TODO
                    OpleidingMonitorPageDto[] dto = JsonConvert.DeserializeObject<OpleidingMonitorPageDto[]>(responseData);
                    return dto;
                }

                return null;
            }
        }

        public async Task InschrijvenAsync(int opleidingId, string persoonId)
        {
            // Validate input
            if (opleidingId <= 0 || string.IsNullOrEmpty(persoonId))
            {
                throw new ArgumentException("OpleidingId and PersoonId are required.");
            }

            // Prepare DTO
            var inschrijvenDto = new
            {
                OpleidingId = opleidingId,
                PersoonId = persoonId
            };

            using (HttpClient client = new HttpClient())
            {
                string jsonContent = JsonConvert.SerializeObject(inschrijvenDto);
                HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync($"{baseUrl}/Inschrijven", httpContent);

                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error during Inschrijven (Status {response.StatusCode}): {errorMessage}");
                }
            }
        }
    }
}