using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using Ziekenfonds.MVC.DTOS;
using ZiekenFonds.Web.DTOS.Monitor;

namespace ZiekenFonds.Web.Services.Monitor
{
    public class MonitorService : IMonitorService
    {
        // Service moet de locatie van de api kennen
        private string apiUrl = "https://localhost:7027/Monitor";

        public async Task CreateMonitorAsync(CreateMonitorDTO dto)
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonContent = JsonConvert.SerializeObject(dto);
                HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, httpContent);
            }
        }

        public async Task<MonitorGegevensDTO[]> GetAllMonitorsWithDetailsAsync()
        {
            // Alle communicatie via API's verloopt via een Http Client
            using (HttpClient client = new HttpClient())
            {
                string fullPath = $"{apiUrl}/MonitorsMetNaam";
                HttpResponseMessage response = await client.GetAsync(fullPath);

                if (response.IsSuccessStatusCode)
                {
                    // API geven data bijna altijd in JSON formaat  AKA een string
                    string responseData = await response.Content.ReadAsStringAsync();

                    MonitorGegevensDTO[] dto = JsonConvert.DeserializeObject<MonitorGegevensDTO[]>(responseData);
                    return dto;
                }

                return null;
            }
        }

        public async Task<MonitorDTO?> GetMonitorAsync(int id)
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

                    MonitorDTO dto = JsonConvert.DeserializeObject<MonitorDTO>(responseData);
                    return dto;
                }

                return null;
            }
        }
    }
}