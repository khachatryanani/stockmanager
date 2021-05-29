using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient
{
    public class WorkerHttpClient: DataHttpClient
    {
        public WorkerHttpClient(HttpClient httpClient) : base(httpClient)
        {

        }

        public async Task<bool> CreateWorker(WorkerViewModel worker)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("Workers", UriKind.Relative)
            };
            string stringContent = JsonSerializer.Serialize(worker);
            request.Content = new StringContent(stringContent, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(request.RequestUri, request.Content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateWorker(WorkerViewModel worker)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"Workers/{worker.workerId}", UriKind.Relative)
            };

            string stringContent = JsonSerializer.Serialize(worker);
            request.Content = new StringContent(stringContent, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(request.RequestUri, request.Content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteWorker(int workerId)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"Workers/{workerId}", UriKind.Relative)
            };

            HttpResponseMessage response = await _httpClient.DeleteAsync(request.RequestUri);

            return response.IsSuccessStatusCode;
        }
    }
}
