using Newtonsoft.Json;
using ZiekenFonds.Web.DTOS.Deelnemer;
using ZiekenFonds.Web.DTOS.Opleiding;

namespace ZiekenFonds.Web.Services.Deelnemers
{
    public class DeelnemerService : IDeelnemerService
    {
        private string apiUrl = "https://localhost:7027/api/Groepsreis";

        public async Task<DeelnemersVanReisOphalenDTO[]> GetAllDeelnemersVanReis()
        {
            using (HttpClient httpClient = new HttpClient()) 
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
                        DeelnemersVanReisOphalenDTO[] dto = JsonConvert.DeserializeObject<DeelnemersVanReisOphalenDTO[]>(responseData);
                        return dto;
                    }

                    return null;
                }
            }
        }
    }
}
