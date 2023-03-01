using DadJokeAPI.Models;
using System;
using System.Diagnostics.Metrics;

namespace DadJokeAPI.Helper
{
    public class ConnectAPIService
    {
        HttpClient client;
        string url;
        string key;
        public ConnectAPIService(IConfiguration configuration)
        {
            client = new HttpClient();
            url = configuration["Service:URL"];
            key = configuration["Service:ApiKey"];
        }
        public Task<DadJoke> ReturnDadJoke()
        {
            return GetJoke();
        }
        public Task<int> ReturnCount()
        {
            return GetCount();
        }
        private HttpRequestMessage getRequest(string url)
        {

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://dad-jokes.p.rapidapi.com/" + url),
                Headers =
                        {
                            { "X-RapidAPI-Key", key },
                            { "X-RapidAPI-Host", "dad-jokes.p.rapidapi.com" },
                        },
            };
            return request;
        }
        private async Task<int> GetCount()
        {
            var request = getRequest("joke/count");
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<CountJoke>();
                return Convert.ToInt32(result.body!);
            }
        }
        private async Task<DadJoke> GetJoke()
        {
            var request = getRequest("random/joke");
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<DadJoke>();
                return result!;
            }
        }
    }
}
