using Newtonsoft.Json;
using System.Text;
using ZiekenFonds.Web.DTOS.Opleiding;
using ZiekenFonds.Web.DTOS.Review;

namespace ZiekenFonds.Web.Services.Review
{
    public class ReviewServices : IReviewServices
    {
        private string apiUrl = "https://localhost:7027/api/Review";

        public async Task CreateReviewAsync(CreateReviewPageDto dto)
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonContent = JsonConvert.SerializeObject(dto);
                HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync($"{apiUrl}/CreateReview", httpContent);
            }
        }

        public async Task<ReviewOphalenPageDto[]> GetAllReviewsAsync()
        {
            // Alle communicatie via API's verloopt via een Http Client
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/GetAll");

                if (response.IsSuccessStatusCode)
                {
                    // API geven data bijna altijd in JSON formaat  AKA een string
                    string responseData = await response.Content.ReadAsStringAsync();

                    // TODO
                    ReviewOphalenPageDto[] dto = JsonConvert.DeserializeObject<ReviewOphalenPageDto[]>(responseData);
                    return dto;
                }

                return null;
            }
        }
    }
}