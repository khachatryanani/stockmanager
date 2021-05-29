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
    public class StockHttpClient : DataHttpClient
    {
        public StockHttpClient(HttpClient httpClient): base(httpClient)
        {
           
        }

        public async Task<bool> CreateStockItem(StockItemBaseViewModel stockItem)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("Stocks", UriKind.Relative)
            };

            string stringContent = JsonSerializer.Serialize(stockItem);
            request.Content = new StringContent(stringContent, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(request.RequestUri, request.Content);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<StockViewModel>> GetStocks()
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("Stocks", UriKind.Relative)
            };

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string stocksString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<StockViewModel>>(stocksString);
            }

            throw new HttpRequestException(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<StockItemViewModel>> GetStockItems(int stockId)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"Stocks/{stockId}", UriKind.Relative)
            };

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string stocksString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<StockItemViewModel>>(stocksString);
            }

            throw new HttpRequestException(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<StockItemViewModel>> GetExpiredStockItems()
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"ExpiredStock", UriKind.Relative)
            };

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string stocksString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<StockItemViewModel>>(stocksString);
            }

            throw new HttpRequestException(await response.Content.ReadAsStringAsync());
        }
    }
}
