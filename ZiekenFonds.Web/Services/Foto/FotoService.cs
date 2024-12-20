using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using ZiekenFonds.Web.DTOS.Foto;
    
namespace ZiekenFonds.Web.Services
{
    public class FotoService : IFotoService
    {
        private string apiUrl = "https://localhost:7027/api/Foto/{bestemmingId}";

        private string apiUrlCreate = "https://localhost:7027/api/Foto/upload";

        private string apiUrlDelete = "https://localhost:7027/api/Foto/{id}";

        public async Task UploadFotoAsync(UploadFotoDto dto)
        {
            using (HttpClient client = new HttpClient())
            using (var content = new MultipartFormDataContent())
            {
                // Voeg bestemmingId toe
                content.Add(new StringContent(dto.BestemmingId.ToString()), "BestemmingId");

                // Voeg bestand toe
                var streamContent = new StreamContent(dto.File.OpenReadStream());
                streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(dto.File.ContentType);
                content.Add(streamContent, "File", dto.File.FileName);

                // Verstuur het POST-verzoek
                HttpResponseMessage response = await client.PostAsync(apiUrlCreate, content);

                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Failed to upload Foto (Status: {response.StatusCode}): {errorMessage}");
                }
            }
        }

        public async Task DeleteFotoAsync(int id)
        {
            // Validate input
            if (id <= 0)
            {
                throw new ArgumentException("Invalid ID", nameof(id));
            }

            using (HttpClient client = new HttpClient())
            {
                string deleteUrl = apiUrlDelete.Replace("{id}", id.ToString());

                HttpResponseMessage response = await client.DeleteAsync(deleteUrl);

                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error deleting Foto (Status {response.StatusCode}): {errorMessage}");
                }
            }
        }

        public async Task<GetFotoDto[]> GetAllFotosAsync(int bestemmingId)
        {

            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // API geven data bijna altijd in JSON formaat  AKA een string
                    string responseData = await response.Content.ReadAsStringAsync();

                    GetFotoDto[] dto = JsonConvert.DeserializeObject<GetFotoDto[]>(responseData);
                    return dto;
                }

                return null;
            }
        }
    }
}
