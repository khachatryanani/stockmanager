using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient
{
    public class DataHttpClient
    {
        private readonly HttpClient _httpClient;

        public DataHttpClient(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<List<StockViewModel>> GetStocks() 
        {
            HttpRequestMessage request = new HttpRequestMessage();

            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri("Stocks", UriKind.Relative);

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
            HttpRequestMessage request = new HttpRequestMessage();

            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri($"Stocks/{stockId}", UriKind.Relative);

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
