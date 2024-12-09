using System.Net.Http;
using System.Net.Http.Json;
using MedicalPracticeManagementMAUI.Models;

namespace MedicalPracticeManagementMAUI.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5001/api/")
            };
        }

        public async Task<List<Treatment>> GetTreatmentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Treatment>>("Treatments") ?? new List<Treatment>();
        }

        public async Task<bool> CreateTreatmentAsync(Treatment treatment)
        {
            var response = await _httpClient.PostAsJsonAsync("Treatments", treatment);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateTreatmentAsync(Treatment treatment)
        {
            var response = await _httpClient.PutAsJsonAsync($"Treatments/{treatment.Id}", treatment);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTreatmentAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Treatments/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}