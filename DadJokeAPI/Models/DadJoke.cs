using System.Text.Json.Serialization;

namespace DadJokeAPI.Models
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Author
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public object Id { get; set; }
    }

    public class DadJoke
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("setup")]
        public string Setup { get; set; }

        [JsonPropertyName("punchline")]
        public string Punchline { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("likes")]
        public List<object> Likes { get; set; }

        [JsonPropertyName("author")]
        public Author Author { get; set; }

        [JsonPropertyName("approved")]
        public bool? Approved { get; set; }

        [JsonPropertyName("date")]
        public int? Date { get; set; }

        [JsonPropertyName("NSFW")]
        public bool? NSFW { get; set; }

        [JsonPropertyName("shareableLink")]
        public string ShareableLink { get; set; }
    }
}
