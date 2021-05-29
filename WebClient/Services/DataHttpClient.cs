using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient
{
    public class DataHttpClient
    {
        protected readonly HttpClient _httpClient;

        public DataHttpClient(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<List<ProductViewModel>> GetProducts()
        {
            HttpRequestMessage request = new HttpRequestMessage();

            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri("Products", UriKind.Relative);

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<List<ProductViewModel>>(await response.Content.ReadAsStringAsync());
            }

            throw new HttpRequestException(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<CustomerViewModel>> GetCustomers()
        {
            HttpRequestMessage request = new HttpRequestMessage();

            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri("Customers", UriKind.Relative);

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<List<CustomerViewModel>>(await response.Content.ReadAsStringAsync());
            }

            throw new HttpRequestException(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<WorkerViewModel>> GetWorkers()
        {
            HttpRequestMessage request = new HttpRequestMessage();

            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri("Workers", UriKind.Relative);

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<List<WorkerViewModel>>(await response.Content.ReadAsStringAsync());
            }

            throw new HttpRequestException(await response.Content.ReadAsStringAsync());
        }
    }
}
