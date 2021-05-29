using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient
{
    public class OrderHttpClient: DataHttpClient
    {
        public OrderHttpClient(HttpClient httpClient) : base(httpClient)
        {

        }

        public async Task<bool> CreateOrder(OrderBaseViewModel order)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("Orders", UriKind.Relative)
            };

            string stringContent = JsonSerializer.Serialize(order);
            request.Content = new StringContent(stringContent, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(request.RequestUri, request.Content);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<OrderViewModel>> GetOrders(string status)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"Orders?status={status}", UriKind.Relative)
            };

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<List<OrderViewModel>>(await response.Content.ReadAsStringAsync());
            }

            throw new HttpRequestException(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<OrderItemViewModel>> GetOrderItems(int orderId)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"Orders/{orderId}", UriKind.Relative)
            };

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<List<OrderItemViewModel>>(await response.Content.ReadAsStringAsync());
            }

            throw new HttpRequestException(await response.Content.ReadAsStringAsync());
        }

        public async Task<bool> UpdateOrder(OrderViewModel order)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"Orders/{order.orderId}", UriKind.Relative)
            };

            string stringContent = JsonSerializer.Serialize(order);
            request.Content = new StringContent(stringContent, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(request.RequestUri, request.Content);

            return response.IsSuccessStatusCode;
        }
    }
}
