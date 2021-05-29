using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient
{
    public class CustomerHttpClient: DataHttpClient
    {
        public CustomerHttpClient(HttpClient httpClient) : base(httpClient)
        {

        }

        public async Task<bool> CreateCustomer(CustomerViewModel customer)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("Customers", UriKind.Relative)
            };
            string stringContent = JsonSerializer.Serialize(customer);
            request.Content = new StringContent(stringContent, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(request.RequestUri, request.Content);
            return response.IsSuccessStatusCode;            
        }

        public async Task<bool> UpdateCustomer(CustomerViewModel customer)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"Customers/{customer.customerId}", UriKind.Relative)
            };

            string stringContent = JsonSerializer.Serialize(customer);
            request.Content = new StringContent(stringContent, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(request.RequestUri, request.Content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCustomer(int customerId)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"Customers/{customerId}", UriKind.Relative)
            };

            HttpResponseMessage response = await _httpClient.DeleteAsync(request.RequestUri);
            return response.IsSuccessStatusCode;
        }
    }
}
