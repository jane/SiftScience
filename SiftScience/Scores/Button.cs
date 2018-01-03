using Newtonsoft.Json;

namespace SiftScience.Scores
{
    public class Button
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
