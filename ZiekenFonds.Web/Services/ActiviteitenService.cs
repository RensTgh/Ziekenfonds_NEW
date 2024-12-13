using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Ziekenfonds.MVC.DTOS;

namespace ZiekenFonds.Web.Services
{
    public class ActiviteitenService : IActiviteitenService
    {
        // Service moet de locatie van de api kennen
        private string apiUrl = "https://localhost:7027/api/Activiteit";

        public async Task<ActiveitenDTO[]> GetAllActiviteitenAsync()
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
                }

                return null;
            }
        }

        public async Task<ActiveitenDTO?> GetActivityAsync(int id)
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

                    ActiveitenDTO dto = JsonConvert.DeserializeObject<ActiveitenDTO>(responseData);
                    return dto;
                }

                return null;
            }
        }
    }
}