using Newtonsoft.Json;
using System.Text;
using Ziekenfonds.MVC.DTOS;
using ZiekenFonds.Web.DTOS;

namespace ZiekenFonds.Web.Services
{
    public class ActiviteitenService : IActiviteitenService
    {
        // Service moet de locatie van de api kennen
        private string apiUrl = "https://localhost:7027/api/Activiteit";

        private string apiUrlDelete = "https://localhost:7027/api/Activiteit/{url}";

        public async Task<ActiviteitenDTO[]> GetAllActiviteitenAsync()
        {
            // Alle communicatie via API's verloopt via een Http Client
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // API geven data bijna altijd in JSON formaat  AKA een string
                    string responseData = await response.Content.ReadAsStringAsync();

                    // TODO

                    ActiviteitenDTO[] dto = JsonConvert.DeserializeObject<ActiviteitenDTO[]>(responseData);

                    return dto;
                }

                return null;
            }
        }

        public async Task<ActiviteitenDTO?> GetActivityAsync(int id)
        {
            // Alle communicatie via API's verloopt via een Http Client
            using (HttpClient client = new HttpClient())
            {
                string fullPath = $"{apiUrl}/{id}";
                HttpResponseMessage response = await client.GetAsync(fullPath);

                if (response.IsSuccessStatusCode)
                {
                    // API geven data bijna altijd in JSON formaat  AKA een string
                    string responseData = await response.Content.ReadAsStringAsync();

                    ActiviteitenDTO dto = JsonConvert.DeserializeObject<ActiviteitenDTO>(responseData);
                    return dto;
                }

                return null;
            }
        }

        // nieuw
        public async Task CreateActiviteitAsync(CreateActiviteitDTO dto)
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonContent = JsonConvert.SerializeObject(dto);
                HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiUrl, httpContent);
            }
        }

        public async Task DeleteActivityAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invallid Id", nameof(id));
            }

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync($"{apiUrl}/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();

                    throw new HttpRequestException($"Error deleting Activiteit (Status {response.StatusCode}): {errorMessage}");
                }
            }
        }
    }
}