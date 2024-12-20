using Newtonsoft.Json;
using ZiekenFonds.Web.DTOS.Review;

namespace ZiekenFonds.Web.Services.Bestemming
{
    public class BestemmingService : IBestemmingService
    {
        private string apiUrl = "https://localhost:7027/api/Bestemming";

        public async Task<Models.Bestemming[]> GetAllBestemmingenAsync()
        {
            // Alle communicatie via API's verloopt via een Http Client
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}");

                if (response.IsSuccessStatusCode)
                {
                    // API geven data bijna altijd in JSON formaat  AKA een string
                    string responseData = await response.Content.ReadAsStringAsync();

                    // TODO
                    Models.Bestemming[] dtos = JsonConvert.DeserializeObject<Models.Bestemming[]>(responseData);
                    return dtos;
                }

                return null;
            }
        }
    }
}
