using DadJokeAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics.Metrics;

namespace DadJokeAPI.Helper
{
    public class ConnectAPIService
    {
        HttpClient client;
        string key;
        public ConnectAPIService(IConfiguration configuration)
        {
            client = new HttpClient();
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
                var jsonString = await response.Content.ReadAsStringAsync();
                var parsed = JObject.Parse(jsonString);
                return Convert.ToInt32((parsed["body"]));
            }
        }

        private async Task<DadJoke> GetJoke()
        {
            //FOR TEST ONLY  - NOT calling the API to avoid reaching the 50 jokes per day limit.
            
            //string fileName = Path.Combine(Environment.CurrentDirectory, @"JsonTest.json");
            //string jsonString = File.ReadAllText(fileName);
            //var parsed = JObject.Parse(jsonString);
            //var innerNodes = JArray.Parse(parsed["body"].ToString());
            //var dadJoke = innerNodes.Select(x => x.ToObject<DadJoke>()).FirstOrDefault();
            //return dadJoke!;
            var request = getRequest("random/joke");
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                var parsed = JObject.Parse(jsonString);
                var innerNodes = JArray.Parse(parsed["body"].ToString());
                var dadJoke = innerNodes.Select(x => x.ToObject<DadJoke>()).FirstOrDefault();
                return dadJoke!;
            }
        }
    }
}
