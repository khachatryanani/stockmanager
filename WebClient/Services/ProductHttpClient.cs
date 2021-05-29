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
    public class ProductHttpClient: DataHttpClient
    {
        public ProductHttpClient(HttpClient httpClient) : base(httpClient)
        {

        }

        public async Task<bool> CreateProduct(ProductViewModel product)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("Products", UriKind.Relative)
            };

            string stringContent = JsonSerializer.Serialize(product);
            request.Content = new StringContent(stringContent, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(request.RequestUri, request.Content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateProduct(ProductViewModel product)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"Products/{product.productId}", UriKind.Relative)
            };

            string stringContent = JsonSerializer.Serialize(product);
            request.Content = new StringContent(stringContent, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(request.RequestUri, request.Content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"Products/{productId}", UriKind.Relative)
            };

            HttpResponseMessage response = await _httpClient.DeleteAsync(request.RequestUri);

            return response.IsSuccessStatusCode;
        }
    }
}
