using Newtonsoft.Json;
using System.Text;
using ZiekenFonds.Web.DTOS.Opleiding;

namespace ZiekenFonds.Web.Services.Opleiding
{
    public class OpleidingService : IOpleidingServices
    {
        // Service moet de locatie van de api kennen
        // TODO: één url maken en hergebruiken
        private string apiUrl = "https://localhost:7027/api/Opleiding/GetAll";

        private string apiUrlCreate = "https://localhost:7027/api/Opleiding/CreateOpleiding";

        private string apiUrlDelete = "https://localhost:7027/api/Opleiding/{url}";

        public async Task CreateOpleidingAsync(CreateOpleidingPageDto dto)
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonContent = JsonConvert.SerializeObject(dto);
                HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiUrlCreate, httpContent);
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
                string deleteUrl = apiUrlDelete.Replace("{url}", id.ToString());

                HttpResponseMessage response = await client.DeleteAsync(deleteUrl);

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
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // API geven data bijna altijd in JSON formaat  AKA een string
                    string responseData = await response.Content.ReadAsStringAsync();

                    // TODO
                    OpleidingOphalenDto[] dto = JsonConvert.DeserializeObject<OpleidingOphalenDto[]>(responseData);
                    return dto;
                }

                return null;
            }
        }
    }
}