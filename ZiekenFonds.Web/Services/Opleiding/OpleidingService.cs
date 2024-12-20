using Newtonsoft.Json;
using System.Net.Http;
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

        public async Task<OpleidingDto[]> GetAllOpleidingenAsync()
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
                    OpleidingDto[] dto = JsonConvert.DeserializeObject<OpleidingDto[]>(responseData);
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
                HttpResponseMessage response = await client.GetAsync($"{apiMonitorUrl}/MonitorsMetNaam");

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

        public async Task InschrijvenAsync(OpleidingPersoonInschrijvingDto inschrijving)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.PostAsJsonAsync($"{baseUrl}/Inschrijven", inschrijving);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Failed to register: {error}");
                }
            }

        }
    }
}